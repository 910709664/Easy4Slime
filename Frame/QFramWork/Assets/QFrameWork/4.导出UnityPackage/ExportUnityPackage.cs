using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public static class ExportUnityPackage
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/4.导出UnityPackage")]
    private static void MenuClicked()
    {
        var assetPathName = "Assets/QFrameWork";
        var fileName = "QFrameWork_" + DateTime.Now.ToString("yyyyMMdd_hh") + ".unitypackage";
        AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
    }
#endif
}
