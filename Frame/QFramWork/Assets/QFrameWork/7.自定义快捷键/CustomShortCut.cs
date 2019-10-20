using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public class CustomShortCut : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/7.自定义快捷键 %e")]
    private static void MenuClicked()
    {
        EditorApplication.ExecuteMenuItem("QFrameWork/6.MenuItem的复用");
    }
#endif
}
