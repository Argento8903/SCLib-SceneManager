using System;

namespace CSLibrary
{
    /// <summary>
    /// シーンID
    /// </summary>
    public readonly partial struct SceneId : IEquatable<SceneId>
    {
        private readonly int m_value;

        public SceneId( int value ) => m_value = value;

        public override bool Equals( object obj )
        {
            return obj switch
            {
                null => false,
                SceneId x => m_value == x,
                int x => m_value == x,
                _ => false
            };
        }

        public override string ToString() => m_value.ToString();
        public override int GetHashCode() => m_value.GetHashCode();
        public bool Equals( SceneId other ) => m_value == other.m_value;

        public static implicit operator int( SceneId v ) => v.m_value;

        public static bool operator ==( SceneId a , SceneId b ) => a.m_value == b.m_value;
        public static bool operator ==( SceneId a , int b ) => a.m_value == b;
        public static bool operator ==( int a , SceneId b ) => a == b.m_value;

        public static bool operator !=( SceneId a , SceneId b ) => a.m_value != b.m_value;
        public static bool operator !=( SceneId a , int b ) => a.m_value != b;
        public static bool operator !=( int a , SceneId b ) => a != b.m_value;
    }
}