using System.Collections.Generic;
using System.Threading;
using System.Threading.Tasks;
using System.Linq;
using UnityEngine;
using UnityEngine.SceneManagement;
using System.Diagnostics;

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
        [RuntimeInitializeOnLoadMethod( RuntimeInitializeLoadType.AfterSceneLoad )]
        private static void AfterSceneLoad()
        {
            var obj = new GameObject( nameof( SceneTransition ) );

            DontDestroyOnLoad( obj );

            obj.AddComponent<SceneTransition>();
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
        public static async Task<TScene> LoadScene<TScene>( SceneId sceneId , LoadSceneMode mode , CancellationToken token = default ) where TScene : SceneBase
        {
            var scene = await SceneLoader.LoadScene<TScene>( sceneId , mode , token );

            if ( scene == null )
            {
                Debug.LogError( "load scene null error" );
            }
            scene.CanBootable = true;
            return scene;
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
        public static async Task<TScene> LoadScene<TScene>( SceneId sceneId , ISceneData sceneData , LoadSceneMode mode , CancellationToken token = default ) where TScene : SceneBase
        {
            var scene = await SceneLoader.LoadScene<TScene>( sceneId , mode , token );

            if ( scene == null )
            {
                Debug.LogError( "load scene null error" );
            }

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
        public static async Task<TScene> LoadSceneAdditive<TScene>( SceneId sceneId , CancellationToken token = default ) where TScene : SceneBase
        {
            return await LoadScene<TScene>( sceneId , LoadSceneMode.Additive , token );
        }

        /// <summary>
        /// シーン加算読み込み
        /// </summary>
        /// <typeparam name="TScene"></typeparam>
        /// <param name="sceneId">シーンID</param>
        /// <param name="sceneData">シーンデータ</param>
        /// <param name="token">キャンセルトークン</param>
        /// <returns></returns>
        public static async Task<TScene> LoadSceneAdditive<TScene>( SceneId sceneId , ISceneData sceneData , CancellationToken token = default ) where TScene : SceneBase
        {
            return await LoadScene<TScene>( sceneId , sceneData , LoadSceneMode.Additive , token );
        }
    }
}
