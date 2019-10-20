using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Slime : MonoBehaviour
{
    public int PlayerID;            //玩家id

    //玩家1、2的跳跃按键
    private KeyCode[] mJumpCode = { KeyCode.W, KeyCode.UpArrow };
    //玩家1、2的质量转换按键
    private KeyCode[] mTransformCodes = { KeyCode.S, KeyCode.DownArrow };

    public Vector3 Volum;      //史莱姆初始体积
    
    public int Quality = 1000;      //史莱姆质量
    public int MoveSpeed = 10;      //移动速度           
    public int JumpSpeed = 10;      //跳跃速度
    public int AttackValue = 5;     //攻击力

    public double AttackCD;                 //攻击CD
    private double mAttackTimer = 0;        //攻击CD计时器
    public double TransferCD;               //转换质量CD
    private double mTransferTimer = 0;      //转换质量CD计时器

    bool mIsGround = false;                 //是否在地面上

    public Animator anim;
    private Rigidbody2D rb;
    public Transform mGroundCheck;
    

    public void Init()
    {
        rb = GetComponent<Rigidbody2D>();
        Volum = transform.localScale;
    }

    void Start()
    {
        Init();
    }
    
    void FixedUpdate()
    {
        Move();             //行动和跳跃

        if (Input.GetKeyDown(mTransformCodes[PlayerID]))
        {
            int anotherSlimeID = (PlayerID == 0 ? 1 : 0);      //获得另一个slime的Id
            GetQuality(PlayerID,anotherSlimeID);
        }
    }

    /// <summary>
    /// 从另一史莱姆获得质量
    /// </summary>
    /// <param name="thisSlimeID">此史莱姆Id</param>
    /// <param name="anotherSlimeID">另一个史莱姆的ID</param>
    private void GetQuality(int thisSlimeID,int anotherSlimeID)
    {
        //调用GameManager的交互方法
        GameManager.Instance.TransferQuality(thisSlimeID, anotherSlimeID);        
    }

    /// <summary>
    /// 移动方法
    /// </summary>
    private void Move()
    {
        float h = Input.GetAxis("Horizontal" + PlayerID.ToString());
        if (h != 0)
        {
            transform.Translate(Vector3.right * h * Time.fixedDeltaTime * MoveSpeed);
        }
        Jump();        
    }

    /// <summary>
    /// 跳跃
    /// </summary>
    private void Jump()
    {
        if (Input.GetKey(mJumpCode[PlayerID]) && mIsGround)
        {
            rb.velocity = Vector2.zero;
            rb.AddForce(Vector3.up * JumpSpeed * 50);
        }
        //射线检测是否在地面
        //Debug.DrawLine(transform.position + Vector3.down * 0.3f, Vector2.down,Color.red,1f);
            
        RaycastHit2D hitInfo = Physics2D.Raycast(mGroundCheck.position, Vector2.down,0.1f);
        if (hitInfo.transform == null || hitInfo.transform.tag != "Ground")
        {
            mIsGround = false;
        }
        else
        {
            mIsGround = true;
        }
    }

    private void GetHurt()
    {

    }

    private void Attack()
    {

    }

    private void Die()
    {
            
    }
}
