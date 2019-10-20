using System.Collections;
using System.Collections.Generic;
using UnityEngine;
#if UNITY_EDITOR
    using UnityEditor;
#endif
public class PercentFunction : MonoBehaviour
{
#if UNITY_EDITOR
    [MenuItem("QFrameWork/12.概率函数")]
#endif
    private static void MenuClicked()
    {
        Debug.Log(Percent(50));
    }

    public static bool Percent(int percent)
    {
        return Random.Range(0, 100) <= percent;
    }
}
