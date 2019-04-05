﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
	public Vector3 offset;
    public bool useOffset;
    public float rotateSpeed = 5;
    public Transform pivot;
    public float maxCameraAngle = 60f;
    public float minCameraAngle = -60f;

    void Start()
    {
        if(!useOffset) {
            offset = target.transform.position - transform.position;
        }

        pivot.position = target.transform.position;
        pivot.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        target.transform.Rotate(0, horizontal, 0);
        pivot.Rotate(-vertical, 0, 0);

        if(pivot.rotation.eulerAngles.x > maxCameraAngle && pivot.rotation.eulerAngles.x < 180f) {
            pivot.rotation = Quaternion.Euler(maxCameraAngle, 0, 0);
        }
        //Debug.Log(pivot.rotation.eulerAngles.x);
        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 360f + minCameraAngle) {
            pivot.rotation = Quaternion.Euler(360f + minCameraAngle, 0, 0);
        }

        float desiredYAngle = target.transform.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.transform.position - (rotation * offset);

    	//transform.position = target.transform.position - offset;
        //transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));

        if(transform.position.y < target.transform.position.y) {
            transform.position = new Vector3(transform.position.x,target.transform.position.y - 0.5f,transform.position.z);            
        }
        transform.LookAt(target.transform);
    }
}
