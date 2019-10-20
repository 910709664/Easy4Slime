using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public static class OpenInFolder 
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/5.打开所在文件夹")]
    private static void MenuClicked()
    {
        Application.OpenURL("file:///" + Application.dataPath);
    }
#endif
}
