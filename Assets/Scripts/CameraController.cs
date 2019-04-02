using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    public GameObject target;
	public Vector3 offset;

    void Start()
    {
        offset = target.transform.position - transform.position;
    }

    // Update is called once per frame
    void Update()
    {
    	transform.position = target.transform.position - offset;
        //transform.LookAt(new Vector3(target.transform.position.x,0f,target.transform.position.z));
    }
}
