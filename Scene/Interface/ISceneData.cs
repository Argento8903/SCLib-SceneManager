namespace CSLibrary
{
    /// <summary>
    /// 各シーンデータ
    /// </summary>
    public interface ISceneData
    {
        
    }

    public static class SceneDataExtensitons
    {
        /// <summary>
        /// 変換用
        /// </summary>
        public static T As<T>(this ISceneData self) where T : class, ISceneData
        {
            return self as T;
        }
    }
}
