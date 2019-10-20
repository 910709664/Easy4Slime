using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager:MonoBehaviour
{
    private static List<string> mLevelNames;

    public static int Index { get; set; }

    public static void Init(List<string> levelNames)
    {
        Index = 0;

        mLevelNames = levelNames;
    }

    public static void LoadCurrent()
    {
        SceneManager.LoadScene(mLevelNames[Index]);
    }

    public static void LoadNext()
    {
        Index++;

        if (Index > mLevelNames.Count)        //容错处理
        {
            Index = 0;
        }

        SceneManager.LoadScene(mLevelNames[Index]);
    }
}
