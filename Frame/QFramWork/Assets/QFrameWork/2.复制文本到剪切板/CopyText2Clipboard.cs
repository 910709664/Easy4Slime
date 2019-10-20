using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
 using UnityEditor;
#endif
public static class CopyText2Clipboard
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/2.复制文本到剪切板")]
#endif
    private static void CopyText()
    {
        GUIUtility.systemCopyBuffer = "要复制的关键字";
    }
}
