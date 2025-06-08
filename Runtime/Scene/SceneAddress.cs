using UnityEngine;
using System;

namespace CSLibrary
{
    public sealed partial class SceneAddress
    {
        public static AssetAddress Get( SceneId sceneId )
        {
            sm_addressTable.TryGetValue( sceneId , out var address );
            return address;
        }
    }
}
