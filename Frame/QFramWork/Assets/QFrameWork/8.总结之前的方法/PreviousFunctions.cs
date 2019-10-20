using System;
using System.Collections;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public class PreviousFunctions : MonoBehaviour
{
    public static string GenerateUnityPackage()
    {
        return "QFrameWork_" + DateTime.Now.ToString("yyyyMMdd_h");
    }

    public static void CopyText(string text)
    {
        GUIUtility.systemCopyBuffer = text;
    }

    public static void ExportPackage(string assetPathName, string fileName)
    {
        AssetDatabase.ExportPackage(assetPathName, fileName, ExportPackageOptions.Recurse);
    }

    public static void OpenInFolder(string folderPath)
    {
        Application.OpenURL("file:///" + folderPath);
    }

    public static void CallMenuItem(string menuPath)
    {
        EditorApplication.ExecuteMenuItem(menuPath);
    }
#if UNITY_EDITOR
    [MenuItem("QFrameWork/8.总结之前的方法/1.获取文件名")]
    private static void MenuClicked1()
    {
        Debug.Log(GenerateUnityPackage());
    }

    [MenuItem("QFrameWork/8.总结之前的方法/2.复制文本到剪切板")]
    private static void MenuClicked2()
    {
        CopyText("要复制的关键字");
    }

    [MenuItem("QFrameWork/8.总结之前的方法/3.生成文件名到剪切板")]
    private static void MenuClicked3()
    {
        CopyText(GenerateUnityPackage());
    }

    [MenuItem("QFrameWork/8.总结之前的方法/4.导出UnityPackage")]
    private static void MenuClicked4()
    {
        ExportPackage("Assets/QFrameWork",GenerateUnityPackage()+".unitypackage");
    }

    [MenuItem("QFrameWork/8.总结之前的方法/5.打开所在文件夹")]
    private static void MenuClicked5()
    {
        OpenInFolder(Application.dataPath);
    }

    [MenuItem("QFrameWork/8.总结之前的方法/6.MenuItem的复用")]
    private static void MenuClicked6()
    {
        CallMenuItem("QFrameWork/8.总结之前的方法/4.导出UnityPackage");
        OpenInFolder(Path.Combine(Application.dataPath,"../"));
    }

#endif
}
