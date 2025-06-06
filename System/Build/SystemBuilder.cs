using System.Threading.Tasks;
using UnityEngine;
using CSLibrary;

namespace CSLibrary.BuildSystem
{
    /// <summary>
    /// ゲームの立ち上げに必要なシステムの構築用
    /// </summary>
    public partial class SystemBuilder
    {
        // ============================================================================ 
        // 変数（ private ）
        // ============================================================================
        private static AssetAddress sm_address      = new AssetAddress( "SharedAssets/Builder/SystemBuilder" );
        private static Task         sm_completeTask = null;

        // ============================================================================ 
        // 関数（ public static ）
        // ============================================================================
        /// <summary>
        /// システムの構築
        /// </summary>
        /// <param name="token"></param>
        /// <returns></returns>
        public static Task Construct()
        {
            if ( sm_completeTask != null ) return sm_completeTask;

            sm_completeTask = SystemBuildImpl();

            return sm_completeTask;
        }

        // ============================================================================ 
        // 関数（ private static ）
        // ============================================================================
        /// <summary>
        /// システム構築実装部分
        /// </summary>
        /// <returns></returns>
        private static async Task SystemBuildImpl()
        {
            var asset = Resources.Load<GameObject>( sm_address.Address );

            if ( asset == null )
            {
                throw new System.NullReferenceException(sm_completeTask.ToString());
            }

            var prefab  = GameObject.Instantiate(asset);
            var builder = prefab.GetComponent<SystemBuilderObject>();

            if( builder == null )
            {
                throw new System.NullReferenceException( $"{prefab.name} に {nameof( SystemBuilderObject )}がアタッチされていません" );
            }

            await builder.CompleteBuild;

            Object.Destroy( prefab );
        }
    }
}
