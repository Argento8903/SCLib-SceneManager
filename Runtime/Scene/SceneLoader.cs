using System.Linq;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CSLibrary
{
    /// <summary>
    /// シーンローダー
    /// </summary>
    public static class SceneLoader
    {
        /// ========================================================
        /// 関数( public static )
        /// ========================================================
        /// <summary>
        /// シーンロード
        /// </summary>
        /// <typeparam name="TScene">シーンID</typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="mode">読み込みモード</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadScene<TScene>( SceneId sceneId , LoadSceneMode mode , CancellationToken token = default )
        {
            token.ThrowIfCancellationRequested();

            var sceneName = SceneId.Get( sceneId );

            DebugUtility.Log( $"=== Load {SceneId.Get( sceneId )} ===" , Color.green );

            // 非同期ロード
            var asyncLoad = SceneManager.LoadSceneAsync( sceneName , mode );

            asyncLoad.allowSceneActivation = false;

            // ある程度進むまでメインスレッドで待機しフレームを飛ばす
            while ( asyncLoad.progress < 0.9f )
            {
                await Task.Yield();
            }

            asyncLoad.allowSceneActivation = true;

            // シーンオブジェクト取得
            var scene = SceneManager.GetSceneByPath( SceneAddress.Get( sceneId ).Address );

            if ( !scene.IsValid() )
            {
                Debug.LogError( "Scene is vaild" );

                return default( TScene );
            }

            var sceneBaseComponet = new TaskCompletionSource<TScene>( /*TaskCreationOptions.RunContinuationsAsynchronously*/ );

            SceneManager.sceneLoaded += DoOnSceneLoaded;

            void DoOnSceneLoaded( Scene scene , LoadSceneMode loadSceneMode )
            {
                SceneManager.sceneLoaded -= DoOnSceneLoaded;

                var rootObject = scene.GetRootGameObjects();

                // ベースを持ってるクラスを取得
                var sceneBase = rootObject
                        .Select( s => s.GetComponentInChildren<TScene>( true ) )
                        .FirstOrDefault( s => s != null );

                DebugUtility.Log( $"=== Load Completed {SceneId.Get( sceneId )} ===" , Color.green );

                sceneBaseComponet.TrySetResult( sceneBase );
            }

            await sceneBaseComponet.Task;

            return sceneBaseComponet.Task.Result;
        }

        /// <summary>
        /// シーンアンロード
        /// </summary>
        /// <param name="sceneId">シーンID</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task UnLoadScene( SceneId sceneId , CancellationToken token = default )
        {
            token.ThrowIfCancellationRequested();

            var scene = SceneManager.GetSceneByPath( SceneAddress.Get( sceneId ).Address );

            if ( !scene.IsValid() )
            {
                Debug.LogError( "Scene is vaild" );
                return;
            }

            // 非同期アンロード
            var asyncUnLoad = SceneManager.UnloadSceneAsync( scene );

            if ( asyncUnLoad == null )
            {
                return;
            }

            // 完了するまでスキップ
            while ( !asyncUnLoad.isDone )
            {
                await Task.Yield();
            }
        }
    }
}