using UnityEngine;
using System.Runtime.InteropServices;

public class SMApplicationHelper
{
	
	#if UNITY_IOS
	[DllImport("__Internal")]
	private static extern string SixMinuteVersion();
	
	[DllImport("__Internal")]
	private static extern string SixMinuteBuild();
	
	#elif UNITY_ANDROID
	private static AndroidJavaClass _smSharedClass;
	private static AndroidJavaClass sharedClass { get {
			if(null == _smSharedClass)
			{
				_smSharedClass = new AndroidJavaClass("com.sixminute.smlibrary.SMHelper");
			}
			return _smSharedClass;
		} }
	
	private const string GET_VERSION_NAME = "GetVersionName";
	
	private const string GET_VERSION_CODE = "GetVersionCode";
	
	#endif
	
	public static string BundleVersion()
	{
		string version = null;
		
		if( IsOnDevice() )
		{
			#if UNITY_IOS
			version = SixMinuteVersion();
			
			#elif UNITY_ANDROID
			version = sharedClass.CallStatic<string>(GET_VERSION_NAME);
			
			#endif
		}
		#if UNITY_EDITOR
		else
		{
			version = UnityEditor.PlayerSettings.bundleVersion;
		}
		#endif
		
		return version;
	}
	
	public static string BundleBuildCode()
	{
		string buildcode = null;
		
		if( IsOnDevice() )
		{
			#if UNITY_IOS
			buildcode = SixMinuteBuild();
			
			#elif UNITY_ANDROID
			buildcode = sharedClass.CallStatic<string>(GET_VERSION_CODE);
			#endif
		}
		
		return buildcode;
	}
	
	public static bool IsOnDevice()
	{
		#if UNITY_IOS
		return IsAvailableOn(RuntimePlatform.IPhonePlayer);
		
		#elif UNITY_ANDROID
		return IsAvailableOn(RuntimePlatform.Android);
		
		#endif
	}
	
	public static bool IsAvailableOn(RuntimePlatform platform)
	{
		bool available = false;
		
		available = Application.platform == platform;
		
		// Debug.Log("IsAvailable: " + available + ", " + platform + ", " + Application.platform);
		
		return available;
	}
}
