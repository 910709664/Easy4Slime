using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

     public float moveSpeed=5f;
     public float runSpeed = 10f;
     public float gravity = 9.8f;
     private Vector3 moveDirection=Vector3.zero;
     private CharacterController playerController;
     private Animator Anim;

     private Rigidbody rd;
	// Use this for initialization
	void Start ()
    {
        playerController = transform.GetComponent<CharacterController>();
        Anim = transform.GetComponent<Animator>();
        rd = transform.GetComponent<Rigidbody>();
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
                moveDirection = new Vector3(h, 0, v);
                transform.LookAt(moveDirection + transform.position);
                playerController.Move(moveDirection * moveSpeed * Time.deltaTime);
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



        }
        else
        {
            
            moveDirection.y -= gravity * Time.deltaTime;
            playerController.Move(moveDirection * Time.deltaTime);
        }
    }

    //private void Attack(AnimatorStateInfo animatorInfo)
    //{
    //    Anim.SetInteger("Atk1",1);
    //    if (animatorInfo.normalizedTime > 1f && animatorInfo.IsName("Atk1"))
    //    {
    //        Anim.SetInteger("Atk1",-1);
    //    }
    //}       
}
