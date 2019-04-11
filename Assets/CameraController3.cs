using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController3 : MonoBehaviour
{
    public Transform target;
    public Vector3 offset;
    public float rotateSpeed = 5f;

    public bool useOffset;

    void Start()
    {
        if(!useOffset)
        {
            offset = target.position - transform.position;
        }
    }

    // Update is called once per frame
    void Update()
    {
        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;
        target.Rotate(vertical, horizontal, 0f);
     

        float desiredYAngle = target.eulerAngles.y;
        float desiredXAngle = target.eulerAngles.x;

      

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0f);
        transform.position = target.position - (rotation * offset);

        //transform.position = target.position - offset;
        transform.LookAt(target);
    }
}
