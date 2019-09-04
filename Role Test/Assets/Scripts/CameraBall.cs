using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraBall : MonoBehaviour {

    public float sensitiveMouse = 3f;

    public Transform Target;
    //相对位置
    private Vector3 offset = new Vector3(0.2f, 2.5f, -0.5f);
    private float minScroll = 4;
    private float maxScrool = 21;
    //旋转角度
    private float mX = 0;
    private float mY = 0;
    //角度限制
    private float minLimitmY = -30f;
    private float maxLimitmY = 180f;
    //滚轮放缩视角
    private float scrollDistance = 0;
    public float scrollSpeed = 10f;
    //
    public bool isNeedDamping = true;
    //
    public float Damping = 5f;
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void LateUpdate()
    {   //是否滚轮缩放
        if (Input.GetAxis("Mouse ScrollWheel") != 0)
        {
            offset = ScrollView(offset);
        }
        //固定相机位置并设置空物体位置
        Vector3 goal = new Vector3(Target.position.x, Target.position.y, Target.position.z) + offset;
        transform.position = goal;

        //获取鼠标输入
        mX += Input.GetAxis("Mouse X") * sensitiveMouse;
        mY -= Input.GetAxis("Mouse Y") * sensitiveMouse;
        //范围限制
        mY = ClampAngle(mY, minLimitmY, maxLimitmY);
        //相机旋转
        Quaternion mRotation = Quaternion.Euler(mY, mX, 0);
        if (isNeedDamping)
        {   //插值平滑
            transform.rotation = Quaternion.Slerp(transform.rotation, mRotation, Time.deltaTime * Damping);
        }
        else
        {
            transform.rotation = mRotation;
        }
    }
    //角度限制方法
    private float ClampAngle(float angle, float minAngle, float maxAngle)
    {
        if (angle < -360) angle += 360;
        if (angle > 360) angle -= 360;
        return Mathf.Clamp(angle, minAngle, maxAngle);


    }
    //滚轮缩放方法
    private Vector3 ScrollView(Vector3 offset)
    {
        float scroll = Input.GetAxis("Mouse ScrollWheel");
        scrollDistance -= scroll * scrollSpeed;
        scrollDistance = Mathf.Clamp(scrollDistance, minScroll, maxScrool);
        offset = offset.normalized * scrollDistance;
        return offset;
    }


}


