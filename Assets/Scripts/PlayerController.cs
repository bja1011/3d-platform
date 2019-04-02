using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    public float moveSpeed;
    public float jumpForce;
    public float turnSpeed = 5;
    private Vector3 moveDirection;
    private CharacterController controller;
    public float gravityScale;

    private bool superJumpUsed;
   
    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void FixedUpdate()
    {
 	
        //moveDirection = new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        float odlY = moveDirection.y;
        moveDirection = transform.forward * moveSpeed * Input.GetAxis("Vertical");// new Vector3(Input.GetAxis("Horizontal") * moveSpeed, moveDirection.y, Input.GetAxis("Vertical") * moveSpeed);
        moveDirection.y = odlY;

        if (Input.GetButtonDown("Fire1"))
        {
            moveSpeed = 30;
        }

        if (Input.GetButtonUp("Fire1"))
        {
            moveSpeed = 5;
        }

        if (controller.isGrounded) 
		{
			moveDirection.y = 0f;
	        if ( Input.GetButtonDown("Jump"))
    	    {
        	    moveDirection.y = jumpForce;
        	} 	
    	} 
	    moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale;
       

        if (Input.anyKey)
        {
            Debug.Log(Input.anyKey.ToString());
            foreach (KeyCode kcode in System.Enum.GetValues(typeof(KeyCode)))
            {
                //Debug.Log(kcode);
                //do something with kcode
            }
        }

        controller.Move(moveDirection * Time.deltaTime);

    	//if(Input.GetButtonDown("Fire1")) {
    	transform.Rotate(0,Input.GetAxis("Horizontal")* turnSpeed, 0);
    	//}
    }


}
