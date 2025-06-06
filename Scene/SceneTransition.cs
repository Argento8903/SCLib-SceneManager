using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CSLibrary
{
    /// <summary>
    /// シーン遷移用
    /// 
    /// </summary>
    public sealed class SceneTransition : MonoBehaviour
    {
        /// ========================================================
        /// 変数( private static )
        /// ========================================================
        private static List<GameObject> sm_rootObjects = new List<GameObject>();

        // ============================================================================
        // private static　(初期化みたいなものなので上に実装)
        // ============================================================================
        /// <summary>
        /// シーンのロードタイミングで呼ばれる
        /// </summary>
        [RuntimeInitializeOnLoadMethod(RuntimeInitializeLoadType.AfterSceneLoad)]
        private static void AfterSceneLoad()
        {
            var obj = new GameObject( nameof( SceneTransition ) );

            DontDestroyOnLoad( obj );

            obj.AddComponent<SceneTransition>();

            SceneManager.sceneLoaded += DoOnSceneLoaded;
        }

        /// <summary>
        /// 読み込み時にシーンを起動準備完了にする
        /// </summary>
        /// <param name="scene"></param>
        /// <param name="loadSceneMode"></param>
        private static void DoOnSceneLoaded( Scene scene, LoadSceneMode loadSceneMode )
        {
            scene.GetRootGameObjects( sm_rootObjects );

            var sceneBase = sm_rootObjects.
                Select( s => s.GetComponent<SceneBase>())
                .FirstOrDefault( s => s!=null);

            if ( sceneBase != null )
            {
                sceneBase.CanBootable = false;
            }
        }

        // ============================================================================
        // public static
        // ============================================================================
        /// <summary>
        /// シーン通常読み込み
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="mode">読み込みモード</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadScene<TScene>( SceneId sceneId, LoadSceneMode mode, CancellationToken token )
        {
            return await SceneLoader.LoadScene<TScene>( sceneId, mode, token );
        }

        /// <summary>
        /// シーン通常読み込み
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="sceneData">シーンデータ</param>
        /// <param name="mode">読み込みモード</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadScene<TScene>( SceneId sceneId, ISceneData sceneData, LoadSceneMode mode , CancellationToken token ) where TScene:SceneBase
        {
            var scene = await SceneLoader.LoadScene<TScene>( sceneId, mode, token );

            // ロード完了後にデータを入れて起動可能にする
            scene.RequestSceneData = () => sceneData; 
            scene.CanBootable = true;

            return scene;
        }

        /// <summary>
        /// シーン加算読み込み
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadSceneAdditive<TScene>( SceneId sceneId , CancellationToken token )
        {
            return await LoadScene<TScene>( sceneId, LoadSceneMode.Additive, token );
        }

        /// <summary>
        /// シーン加算読み込み
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="sceneData">シーンデータ</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadSceneAdditive<TScene>( SceneId sceneId , ISceneData sceneData , CancellationToken token ) where TScene : SceneBase
        {
            return await LoadScene<TScene>( sceneId, sceneData, LoadSceneMode.Additive , token );
        }
    }
}
