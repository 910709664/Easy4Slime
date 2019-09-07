using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

     public float moveSpeed=7f;
     public float runSpeed = 12f;
     public float jumpSpeed = 5f;
     public float gravity = 9.8f;
     public float damping = 20f;
     private Vector3 moveDirection=Vector3.zero;
     private CharacterController playerController;
     private Animator Anim;
     

     public GameObject CameraBall;
	// Use this for initialization
	void Start ()
    {
        playerController = transform.GetComponent<CharacterController>();
        Anim = transform.GetComponent<Animator>();
        
    }
	
	// Update is called once per frame
	void FixedUpdate ()
    {
        AnimatorStateInfo animatorInfo;
        animatorInfo = Anim.GetCurrentAnimatorStateInfo(0);
        if (playerController.isGrounded)
        {
            
            float h = Input.GetAxis("Horizontal");
            float v = Input.GetAxis("Vertical");
            if (h != 0 || v != 0)
            {
                Anim.SetInteger("MoveSpeed",1);

                if (Input.GetKey(KeyCode.LeftShift))
                {

                    Anim.SetBool("Run", true);


                }
                else
                {
                    Anim.SetBool("Run", false);
                }
                //moveDirection = new Vector3(h, 0, v);
                //transform.LookAt(moveDirection + transform.position);
                MirDirection(h, v);
                playerController.Move(moveDirection * moveSpeed*Time.deltaTime);
            }
            else
            {
                Anim.SetInteger("MoveSpeed", 0);
            }

            if (Input.GetKeyDown(KeyCode.J))
            {
                Anim.SetInteger("Atk1", 1);
            }
            if (animatorInfo.normalizedTime > 1f && animatorInfo.IsName("Atk1"))
            {
                   Anim.SetInteger("Atk1",-1);
            }

            //if (Input.GetKeyDown(KeyCode.Space))
            //{
            //    Anim.SetBool("Jump", true);
            //    moveDirection.y = jumpSpeed;
            //    playerController.Move(moveDirection * Time.deltaTime);
            //    Debug.Log("Jumping");
                
                                
            //}

            //if (animatorInfo.normalizedTime >= 1f && animatorInfo.IsName("Jump"))
            //{
            //    Anim.SetBool("Jump", false);
            //}

        }
        
            
            moveDirection.y -= gravity * Time.deltaTime;
            playerController.Move(moveDirection * Time.deltaTime);
        
    }

    //private void Attack(AnimatorStateInfo animatorInfo)
    //{
    //    Anim.SetInteger("Atk1",1);
    //    if (animatorInfo.normalizedTime > 1f && animatorInfo.IsName("Atk1"))
    //    {
    //        Anim.SetInteger("Atk1",-1);
    //    }
    //}       
    private void MirDirection(float h, float v)
    {
        if (v > 0)
        {
            moveDirection = new Vector3(CameraBall.transform.forward.x, 0, CameraBall.transform.forward.z);
        }
        if (v < 0)
        {
            moveDirection = new Vector3(-CameraBall.transform.forward.x, 0, -CameraBall.transform.forward.z);
        }
        if (h > 0)
        {
            moveDirection = new Vector3(CameraBall.transform.right.x, 0, CameraBall.transform.right.z);
        }
        if (h < 0)
        {
            moveDirection = new Vector3(-CameraBall.transform.right.x, 0, -CameraBall.transform.right.z);
        }
        Quaternion roleQuaternion = Quaternion.LookRotation(moveDirection);
        transform.rotation = Quaternion.Slerp(transform.rotation, roleQuaternion, damping * Time.deltaTime);


    }
}
