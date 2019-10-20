using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager :MonoBehaviour
{   
    //单例
    public static GameManager Instance;

    public float M2VRate = 0.05f;   //质量体积转换率
    public int TempQuality = 150;   //每次转换的体积
    public float TempMass = 0.2f;
    
    private int mQualitySum;            //史莱姆质量总合
    public int mMinQuality = 200;       //最小质量    

    private Transform[] mSlimeTransforms;
    private Slime[] mSlimes;
    private Rigidbody2D[] mSlimeRb;
               
    void Awake()
    {
        Instance = this;
    }

    void Start()
    {
       Init();
    }

    private void Init()
    {
        mSlimes = new Slime[2];
        mSlimeTransforms = new Transform[2];
        mSlimeRb=new Rigidbody2D[2];

        //获取组件
        for (int i = 0; i < 2; i++)
        {
            GameObject slime = GameObject.Find("Slime" + i.ToString());
            mSlimes[i] = slime.GetComponent<Slime>();
            mSlimeTransforms[i] = slime.GetComponent<Transform>();
            mSlimeRb[i] = slime.GetComponent<Rigidbody2D>();
        }
        GetQualitySum();        
    }

    /// <summary>
    /// 转换质量
    /// 按下自身增加，对方减少
    /// </summary>
    /// <param name="toSlimeID">质量转换目标</param>
    /// <param name="fromSlimeID">质量转换来源</param>
    public void TransferQuality(int toSlimeID,int fromSlimeID)
    {
        //判断是否能够继续转换
        if (ClampQuality(toSlimeID, fromSlimeID) == false)
            return;

        ChangeQuality(toSlimeID, TempQuality);          //改变目标史莱姆质量
        ChangeQuality(fromSlimeID, -TempQuality);       //改变来源史莱姆质量   
    }

    /// <summary>
    /// 获得质量总和
    /// </summary>
    private void GetQualitySum()
    {
        mQualitySum = mSlimes[0].Quality + mSlimes[1].Quality;
    }

    /// <summary>
    /// 检测增加减少的质量
    /// </summary>
    /// <param name="toSlimeID"></param>
    /// <param name="fromSlimeID"></param>
    /// <returns></returns>
    private bool ClampQuality(int toSlimeID,int fromSlimeID)
    {
        int fromQuality = mSlimes[fromSlimeID].Quality;
        int toQuality = mSlimes[toSlimeID].Quality;
        if ((fromQuality - TempQuality) < mMinQuality)
            return false;
        return true;
    }

    /// <summary>
    /// 改变质量
    /// </summary>
    /// <param name="id">史莱姆ID</param>
    /// <param name="quality">质量数值</param>
    public void ChangeQuality(int id,int quality)
    {
        mSlimes[id].Quality += quality;
        Vector3 tempVolumn = Vector3.one * M2VRate * 0.005f * quality;
        mSlimes[id].Volum += tempVolumn;
        mSlimeTransforms[id].localScale = mSlimes[id].Volum;
    }
}
