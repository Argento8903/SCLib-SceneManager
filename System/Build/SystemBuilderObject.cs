using System.Threading;
using System.Threading.Tasks;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace CSLibrary.BuildSystem
{
    /// <summary>
    /// ゲームの立ち上げに必要なシステムの構築用
    /// </summary>
    public partial class SystemBuilderObject : MonoBehaviour
    {
        // ============================================================================ 
        // 変数（ private ）
        // ============================================================================
        private CancellationTokenSource       m_token             = new CancellationTokenSource();
        private TaskCompletionSource<object>  m_completeBuildTask = new TaskCompletionSource<object>();

        // ============================================================================ 
        // プロパティ（ public ）
        // ============================================================================
        /// <summary>
        /// ビルド完了
        /// </summary>
        public Task CompleteBuild => m_completeBuildTask.Task;

        // ============================================================================ 
        // 関数（ MonoBehaviour ）
        // ============================================================================
        private void OnDestroy()
        {
            m_token.Cancel();
        }

        private async void Start()
        {
            try
            {
                var token = m_token.Token;

                if (token != null)
                {
                    DebugUtility.Log( "=== System Build Start ===", Color.green );

                    DebugUtility.Log( "=== Shared Scene Load Start ===", Color.green );

                    await SceneLoader.LoadScene<SharedCameraScene>( SceneId.SharedCameraScene, LoadSceneMode.Additive, token ); // 共有カメラ
                    await SceneLoader.LoadScene<SharedUIScene>( SceneId.SharedUIScene, LoadSceneMode.Additive, token ); // 共有カメラ

                    DebugUtility.Log( "=== Shared Scene Load End ===", Color.green );

                    m_completeBuildTask.SetResult( null );

                    DebugUtility.Log( "=== System Build End ===" , Color.green );

                    return;
                }
            }
            catch
            {
                throw;
            }
        }
    }
}
