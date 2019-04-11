using System.Collections;
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
        //pivot.parent = target.transform;
        pivot.parent = null;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void LateUpdate()
    {
        pivot.transform.position = target.transform.position;

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        pivot.Rotate(0, horizontal, 0);
        pivot.Rotate(-vertical, 0, 0);

        if(pivot.rotation.eulerAngles.x > maxCameraAngle && pivot.rotation.eulerAngles.x < 180f) {
            pivot.rotation = Quaternion.Euler(maxCameraAngle, 0, 0);
        }
        //Debug.Log(pivot.rotation.eulerAngles.x);
        if(pivot.rotation.eulerAngles.x > 180 && pivot.rotation.eulerAngles.x < 315f + minCameraAngle) {
            pivot.rotation = Quaternion.Euler(315f + minCameraAngle, 0, 0);
        }

        float desiredYAngle = pivot.eulerAngles.y;
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
