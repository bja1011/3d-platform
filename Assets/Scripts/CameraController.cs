using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
	public Vector3 offset;
    public float rotateSpeed = 5;
    public Transform pivot;

    void Start()
    {
        offset = target.transform.position - transform.position;

        pivot.position = target.transform.position;
        pivot.parent = target.transform;

        Cursor.lockState = CursorLockMode.Locked;
    }

    // Update is called once per frame
    void Update()
    {

        float horizontal = Input.GetAxis("Mouse X") * rotateSpeed;
        float vertical = Input.GetAxis("Mouse Y") * rotateSpeed;

        target.transform.Rotate(0, horizontal, 0);
        pivot.Rotate(-vertical, 0, 0);


        float desiredYAngle = target.transform.eulerAngles.y;
        float desiredXAngle = pivot.eulerAngles.x;

        Quaternion rotation = Quaternion.Euler(desiredXAngle, desiredYAngle, 0);

        transform.position = target.transform.position - (rotation * offset);

    	//transform.position = target.transform.position - offset;
        //transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));
        transform.LookAt(target.transform);
    }
}
