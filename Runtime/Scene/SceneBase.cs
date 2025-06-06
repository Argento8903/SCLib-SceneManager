using CSLibrary.BuildSystem;
using System;
using System.Threading;
using System.Threading.Tasks;
using UnityEngine;

namespace CSLibrary
{
    /// <summary>
    /// Sceneベースクラス
    /// ※とりあえずMono関数色々使用
    /// </summary>
    public abstract partial class SceneBase : MonoBehaviour, IScene
    {
        // ============================================================================ 
        // 変数（ private ）
        // ============================================================================
        private CancellationTokenSource         m_tokenSource   = new CancellationTokenSource();
        private TaskCompletionSource<SceneBase> m_onSetupScene  = new TaskCompletionSource<SceneBase>();

        // ============================================================================
        // プロパティ（ public ）
        // ============================================================================ 
        /// <summary>
        /// シーンセットアップ完了待機タスク
        /// </summary>
        public Task WaitSetupScene => m_onSetupScene.Task;

        /// <summary>
        /// シーンデータリクエスト用
        /// </summary>
        public Func<ISceneData> RequestSceneData { private get; set; }

        // ============================================================================
        // IScene プロパティ（ public ）
        // ============================================================================ 
        /// <summary>
        /// ロード済み
        /// </summary>
        public bool IsLoaded { get; private set; }

        // ============================================================================
        // プロパティ（ public ）
        // ============================================================================ 
        /// <summary>
        /// 起動可能
        /// </summary>
        public bool CanBootable { private get; set; } = true;

        // ============================================================================
        // プロパティ（ protected ）
        // ============================================================================ 
        /// <summary>
        /// 更新可能
        /// </summary>
        protected bool CanUpdate { get; set; }

        // ============================================================================
        // MonoBehaviour 関数（ private ）
        // ============================================================================
        private void Awake()
        {
            DoPreAwake();
            DoAwake();
        }

        private void OnDestroy()
        {
            m_tokenSource.Cancel();

            DoPreDestroy();

            DoDestroy();
        }

        private async void Start()
        {
            var token = m_tokenSource.Token;

            try
            {
                // シーン起動可能まで待機
                await SceneBoot( token );

                // シーンセットアップ完了まで待機
                await SceneSetup( token );

                // ロード完了
                IsLoaded = true;

                // シーン入り
                DoEnterScene();

                // 完了通知
                m_onSetupScene.SetResult( this );
            }
            catch ( OperationCanceledException e )
            {
                if ( e.CancellationToken == token )
                {
                    Debug.LogError( "遷移キュンセルエラー" );
                }
            }
            catch
            {
                throw;
            }
        }
        private void Update()
        {
            if ( !CanUpdate ) return;

            DoPreUpdate( Time.deltaTime );
            DoUpdate( Time.deltaTime );
        }

        private void LateUpdate()
        {
            if ( !CanUpdate ) return;

            DoLateUpdate( Time.deltaTime );
        }

        private void FixedUpdate()
        {
            if ( !CanUpdate ) return;

            DoFixdUpdate();
        }

        // ============================================================================
        // 関数（ private ）
        // ============================================================================

        /// <summary>
        /// シーン起動
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task SceneBoot( CancellationToken token )
        {
            token.ThrowIfCancellationRequested();

            // システム構築
            await SystemBuilder.Construct();

            while ( !CanBootable )
            {
                await Task.Yield();
            }

            await Task.CompletedTask;
        }

        /// <summary>
        /// シーンセットアップ
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        private async Task SceneSetup( CancellationToken token )
        {
            token.ThrowIfCancellationRequested();

            var sceneData = RequestSceneData?.Invoke() ?? GetDefaultSceneData();

            await DoSceneSetup( sceneData , token );
        }

        // ============================================================================
        // 関数（ protected ）
        // ============================================================================
        protected virtual ISceneData GetDefaultSceneData() => null;

        protected virtual void DoPreAwake() { }
        protected virtual void DoAwake() { }

        protected virtual void DoPreDestroy() { }
        protected virtual void DoDestroy() { }

        protected virtual async Task DoSceneSetup( ISceneData sceneData , CancellationToken token ) => await Task.CompletedTask;
        protected virtual void DoEnterScene() { }

        protected virtual void DoPreUpdate( float dt ) { }
        protected virtual void DoUpdate( float dt ) { }
        protected virtual void DoLateUpdate( float dt ) { }
        protected virtual void DoFixdUpdate() { }
    }

}
