using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform target;
    //最大距离
    public float distance = 3f;
    //拉近速度
    public float damp = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {   //相对位置
        Vector3 dirVector3 = transform.position - target.position;
        //在相对位置发射一条射线检测，如果在最大距离检测到地形隔绝则拉近镜头到碰撞点
        Ray ray = new Ray(target.position, dirVector3);
        RaycastHit hitInfo;
        if (Physics.Raycast(ray, out hitInfo, distance, LayerMask.GetMask("Plane")))
        {   //插值平滑拉近
            transform.position = Vector3.Lerp(transform.position, hitInfo.point, Time.deltaTime * damp);
        }
        //如果离开隔绝物体则拉回原来距离
        else
        {
            if (dirVector3.sqrMagnitude < 25f)
            {
                transform.position = target.position - transform.forward * 5f;
            }
        }
    }

}
