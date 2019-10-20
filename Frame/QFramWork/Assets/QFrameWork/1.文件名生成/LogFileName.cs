
#if UNITY_EDITOR
using UnityEditor;
#endif

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public static class LogFileName 
{
            #if UNITY_EDITOR
            [MenuItem("QFrameWork/1.生成 unitypackage 名字")]
            #endif
    private static void GenerateUnityPackageName()
    {
        Debug.Log("QFrameWork_"+DateTime.Now.ToString("yyyyMMdd_hh"));
    }
}
