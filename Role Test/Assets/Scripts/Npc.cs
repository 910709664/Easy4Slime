using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Npc : MonoBehaviour
{

    private CharacterController npcPlayerControl;

    private Vector3 moveDirection = Vector3.zero;

    public float gravity = 9.8f;
	// Use this for initialization
	void Start ()
    {
        npcPlayerControl = transform.GetComponent<CharacterController>();
    }
	
	// Update is called once per frame
	void FixedUpdate () {

        if (npcPlayerControl.isGrounded)
        {

        }
        else
        {
            moveDirection.y -= gravity * Time.deltaTime;
            npcPlayerControl.Move(moveDirection * Time.deltaTime);
        }
        
	}
}
