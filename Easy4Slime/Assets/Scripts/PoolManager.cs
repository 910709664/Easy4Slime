using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoolManager
{
    private PoolManager mInstance;
    public PoolManager Instance
    {
        get
        {
            if (mInstance == null)
                mInstance = new PoolManager();
            return mInstance;
        }
    }

    private Dictionary<string, List<GameObject>> mPools;          //对象池
    private Dictionary<string, GameObject> mPrefabs;              //预制体
    private Dictionary<string, Transform> mParents;               //父物体

    public PoolManager()
    {
        mPools = new Dictionary<string, List<GameObject>>();
        mPrefabs = new Dictionary<string, GameObject>();
        mParents = new Dictionary<string, Transform>();        
    }

    /// <summary>
    /// 添加一个对象池
    /// </summary>
    /// <param name="prefabPath">预制体路径</param>
    /// <param name="key">对象池关键字</param>
    /// <param name="parent">对象池父物体</param>
    private void AddPool(string prefabPath,string key,Transform parent)
    {
        mPools.Add(key, new List<GameObject>());
        mPrefabs.Add(key, Resources.Load<GameObject>(prefabPath));
        mParents.Add(key, parent);                
    }

    /// <summary>
    /// 申请一个对象
    /// </summary>
    /// <param name="key">对象池名字</param>
    /// <param name="transform">申请对象的位置</param>
    /// <returns></returns>
    public GameObject Spawn(string key, Transform transform)
    {
        if (mPools.ContainsKey(key))
        {
            GameObject go;
            if (mPools[key].Count > 0)
            {
                go = mPools[key][0];
            }
            else
            {
                go = SpawnNew(key);
            }
            go.transform.position = transform.position;
            go.transform.rotation = transform.rotation;
            return go;
        }
        else
        {
            Debug.LogError("找不到对应池");
            return null;
        }
    }

    /// <summary>
    /// 回收一个对象
    /// </summary>
    /// <param name="key">对象池名字</param>
    /// <param name="go">回收对象</param>
    public void Despawn(string key, GameObject go)
    {
        if (mPools.ContainsKey(key))
        {
            go.transform.SetParent(mParents[key]);
            mPools[key].Add(go);
        }
    }

    /// <summary>
    /// 生成一个对象
    /// </summary>
    /// <param name="key">对象池名字</param>
    /// <returns></returns>
    private GameObject SpawnNew(string key)
    {
        GameObject go = Object.Instantiate(mPrefabs[key]).gameObject;
        return go;
    }
}
