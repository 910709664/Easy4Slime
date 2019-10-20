using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
using UnityEditor;
#endif
public static class GenerateUnityPackageName2ClipBoard
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/3.生成文件名到剪切板")]
#endif
    private static void MenuClicked()
    {
        GUIUtility.systemCopyBuffer = "QFrameWork_" + DateTime.Now.ToString("yyyyMMdd_hh");
    }
}
