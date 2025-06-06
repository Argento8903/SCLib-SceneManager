
// ==============================================================================
//
// このファイルはテンプレートから自動生成されます
//
// ==============================================================================

using System;
using System.Collections.Generic;

namespace CSLibrary
{
	// ==============================================================================
	// SceneId
	// ==============================================================================
	public readonly partial struct SceneId
	{
		public static readonly SceneId BootScene = new SceneId(-148677449);
		public static readonly SceneId SplashScreenScene = new SceneId(1443007197);
		public static readonly SceneId SampleScene = new SceneId(1316970090);
		public static readonly SceneId SharedCameraScene = new SceneId(1244969046);
		public static readonly SceneId SharedUIScene = new SceneId(-1936456520);
		public static readonly SceneId FadeSandBox = new SceneId(2109929087);
		public static readonly SceneId FancyScrollSandBox = new SceneId(1331200274);
		public static readonly SceneId FeedbackSandBox = new SceneId(1638741251);
		public static readonly SceneId ModelScene = new SceneId(-1283215143);
		public static readonly SceneId ShooterSandBox = new SceneId(1141671882);

		// ==============================================================================
		// SceneName と SceneId の紐づけ
		// ==============================================================================
		private static readonly Dictionary<string, SceneId> sm_nameToIdTable = new Dictionary<string,SceneId>(StringComparer.OrdinalIgnoreCase)
		{
			{ "BootScene", SceneId.BootScene },
			{ "SplashScreenScene", SceneId.SplashScreenScene },
			{ "SampleScene", SceneId.SampleScene },
			{ "SharedCameraScene", SceneId.SharedCameraScene },
			{ "SharedUIScene", SceneId.SharedUIScene },
			{ "FadeSandBox", SceneId.FadeSandBox },
			{ "FancyScrollSandBox", SceneId.FancyScrollSandBox },
			{ "FeedbackSandBox", SceneId.FeedbackSandBox },
			{ "ModelScene", SceneId.ModelScene },
			{ "ShooterSandBox", SceneId.ShooterSandBox },
		};

		private static readonly Dictionary<SceneId, string> sm_idToNameTable = new Dictionary<SceneId,string>()
		{
			{ SceneId.BootScene, "BootScene" },
			{ SceneId.SplashScreenScene, "SplashScreenScene" },
			{ SceneId.SampleScene, "SampleScene" },
			{ SceneId.SharedCameraScene, "SharedCameraScene" },
			{ SceneId.SharedUIScene, "SharedUIScene" },
			{ SceneId.FadeSandBox, "FadeSandBox" },
			{ SceneId.FancyScrollSandBox, "FancyScrollSandBox" },
			{ SceneId.FeedbackSandBox, "FeedbackSandBox" },
			{ SceneId.ModelScene, "ModelScene" },
			{ SceneId.ShooterSandBox, "ShooterSandBox" },
		};

	    // ==============================================================================
		// Getter
		// ==============================================================================
		public static SceneId Get( string sceneName ) 
		{ 
			if( sm_nameToIdTable.TryGetValue( sceneName, out var id ) )
			{
				return id;
			}

			return default;
		}

		public static string Get( SceneId sceneId ) 
		{ 
			if( sm_idToNameTable.TryGetValue( sceneId, out var name ) )
			{
				return name;
			}

			return string.Empty;
		}
	}

	// ==============================================================================
	// Address
	// ==============================================================================
	public partial class SceneAddress
	{
		private static Dictionary<SceneId, AssetAddress> sm_addressTable = new Dictionary<SceneId, AssetAddress>()
		{
			{ SceneId.BootScene, new AssetAddress( "Assets/HeyBro/Assets/SceneAssets/Boot/BootScene/BootScene.unity" ) },
			{ SceneId.SplashScreenScene, new AssetAddress( "Assets/HeyBro/Assets/SceneAssets/Boot/SplashScreenScene/SplashScreenScene.unity" ) },
			{ SceneId.SampleScene, new AssetAddress( "Assets/HeyBro/Assets/SceneAssets/Boot/TitleScene/SampleScene.unity" ) },
			{ SceneId.SharedCameraScene, new AssetAddress( "Assets/HeyBro/Assets/SharedAssets/Scene/SharedCameraScene.unity" ) },
			{ SceneId.SharedUIScene, new AssetAddress( "Assets/HeyBro/Assets/SharedAssets/Scene/SharedUIScene.unity" ) },
			{ SceneId.FadeSandBox, new AssetAddress( "Assets/HeyBro/Editor/SandBox/FadeSandBox/FadeSandBox.unity" ) },
			{ SceneId.FancyScrollSandBox, new AssetAddress( "Assets/HeyBro/Editor/SandBox/FancyScrollSandBox/FancyScrollSandBox.unity" ) },
			{ SceneId.FeedbackSandBox, new AssetAddress( "Assets/HeyBro/Editor/SandBox/FeedbackSandBox/FeedbackSandBox.unity" ) },
			{ SceneId.ModelScene, new AssetAddress( "Assets/HeyBro/Editor/SandBox/ModelSampleSandBox/ModelScene.unity" ) },
			{ SceneId.ShooterSandBox, new AssetAddress( "Assets/HeyBro/Editor/SandBox/ShooterSandBox/ShooterSandBox.unity" ) },
		};
	}

	// Assets/HeyBro/Assets/SceneAssets/Boot/BootScene/BootScene.unity
	public partial class BootScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Assets/SceneAssets/Boot/SplashScreenScene/SplashScreenScene.unity
	public partial class SplashScreenScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Assets/SceneAssets/Boot/TitleScene/SampleScene.unity
	public partial class SampleScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Assets/SharedAssets/Scene/SharedCameraScene.unity
	public partial class SharedCameraScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Assets/SharedAssets/Scene/SharedUIScene.unity
	public partial class SharedUIScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Editor/SandBox/FadeSandBox/FadeSandBox.unity
	public partial class FadeSandBox
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Editor/SandBox/FancyScrollSandBox/FancyScrollSandBox.unity
	public partial class FancyScrollSandBox
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Editor/SandBox/FeedbackSandBox/FeedbackSandBox.unity
	public partial class FeedbackSandBox
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Editor/SandBox/ModelSampleSandBox/ModelScene.unity
	public partial class ModelScene
	{
		public partial class SceneData : ISceneData
		{

		}
	}
	// Assets/HeyBro/Editor/SandBox/ShooterSandBox/ShooterSandBox.unity
	public partial class ShooterSandBox
	{
		public partial class SceneData : ISceneData
		{

		}
	}

	// ==============================================================================
	// Key
	// ==============================================================================
	public partial class SceneKey<T>
	{
		public static SceneId Id { private set; get; }

		static SceneKey()
		{
			SceneKey<BootScene>.Id = SceneId.BootScene;
			SceneKey<SplashScreenScene>.Id = SceneId.SplashScreenScene;
			SceneKey<SampleScene>.Id = SceneId.SampleScene;
			SceneKey<SharedCameraScene>.Id = SceneId.SharedCameraScene;
			SceneKey<SharedUIScene>.Id = SceneId.SharedUIScene;
			SceneKey<FadeSandBox>.Id = SceneId.FadeSandBox;
			SceneKey<FancyScrollSandBox>.Id = SceneId.FancyScrollSandBox;
			SceneKey<FeedbackSandBox>.Id = SceneId.FeedbackSandBox;
			SceneKey<ModelScene>.Id = SceneId.ModelScene;
			SceneKey<ShooterSandBox>.Id = SceneId.ShooterSandBox;
		}
	}

	public class SceneKey
	{
		private static readonly Dictionary<Type, SceneId> sm_sceneKeyTable = new Dictionary<Type, SceneId>()
		{
			{ typeof(BootScene), SceneId.BootScene },
			{ typeof(SplashScreenScene), SceneId.SplashScreenScene },
			{ typeof(SampleScene), SceneId.SampleScene },
			{ typeof(SharedCameraScene), SceneId.SharedCameraScene },
			{ typeof(SharedUIScene), SceneId.SharedUIScene },
			{ typeof(FadeSandBox), SceneId.FadeSandBox },
			{ typeof(FancyScrollSandBox), SceneId.FancyScrollSandBox },
			{ typeof(FeedbackSandBox), SceneId.FeedbackSandBox },
			{ typeof(ModelScene), SceneId.ModelScene },
			{ typeof(ShooterSandBox), SceneId.ShooterSandBox },
		};

		public static SceneId GetId( Type type )
		{
			if( sm_sceneKeyTable.TryGetValue( type, out var id ) )
			{
				return id;
			}

			return default;
		}
	}
}