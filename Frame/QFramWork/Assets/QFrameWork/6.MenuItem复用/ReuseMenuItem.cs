using System.Collections;
using System.Collections.Generic;
using System.IO;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public class ReuseMenuItem : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/6.MenuItem的复用")]
    private static void MenuClicked()
    {
        EditorApplication.ExecuteMenuItem("QFrameWork/4.导出UnityPackage");
        Application.OpenURL("file:///"+Path.Combine(Application.dataPath,"../"));
        
    }
#endif
}
