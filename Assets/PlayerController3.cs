using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController3 : MonoBehaviour
{

    public float moveSpeed = 5f;
    public float jumpForce = 20;
    public float gravityScale = 5f;
    public CharacterController controller;

    private Vector3 moveDirection;

    void Start()
    {
        controller = GetComponent<CharacterController>();
    }

    void Update()
    {
        moveDirection = new Vector3(Input.GetAxis("Horizontal"), moveDirection.y, Input.GetAxis("Vertical"));

        if(controller.isGrounded)
        {
            moveDirection.y = 0f;
            if (Input.GetButtonDown("Jump"))
            {
                moveDirection.y = jumpForce;
            }
        }

        moveDirection.y = moveDirection.y + Physics.gravity.y * gravityScale * Time.deltaTime;
        controller.Move(moveDirection * moveSpeed * Time.deltaTime);
    }
}
