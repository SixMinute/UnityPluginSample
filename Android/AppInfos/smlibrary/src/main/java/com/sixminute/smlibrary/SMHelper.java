package com.sixminute.smlibrary;

import android.app.Activity;
import android.content.pm.PackageInfo;
import android.content.pm.PackageManager;
import android.util.Log;

import com.unity3d.player.UnityPlayer;

public class SMHelper
{
    public static Activity GetUnityActivity()
    {
        return UnityPlayer.currentActivity;
    }

    public static String GetVersionName()
    {
        return GetVersionName(GetUnityActivity());
    }

    public static String GetVersionName(Activity activity)
    {
        if( null != getPackageInfo(activity) )
        {
            return getPackageInfo(activity).versionName;
        }
        return null;
    }

    public static String GetVersionCode()
    {
        return GetVersionCode(GetUnityActivity());
    }

    public static String GetVersionCode(Activity activity)
    {
        if( null != getPackageInfo(activity) )
        {
            return "" + getPackageInfo(activity).versionCode;
        }
        return null;
    }

    private static PackageInfo getPackageInfo(Activity activity)
    {
        try
        {
            return activity
                    .getPackageManager()
                    .getPackageInfo(activity.getPackageName(), 0);
        } catch (PackageManager.NameNotFoundException e) {
            e.printStackTrace();
            return null;
        }
    }

    private static void _log(String msg)
    {
        Log.d("SMHelper", msg);
    }

    public static void onStart()
    {
        _log("onStart");
    }

    public static void onStop()
    {
        _log("onStop");
    }

    public static void onDestroy()
    {
        _log("onDestroy");
    }

    public static void onRestart()
    {
        _log("onRestart");
    }

    public static void onPause()
    {
        _log("onPause");
    }

    public static void onResume()
    {
        _log("onResume");
    }

    public static void onBackPressed()
    {
        _log("onBackPressed");
    }
}
