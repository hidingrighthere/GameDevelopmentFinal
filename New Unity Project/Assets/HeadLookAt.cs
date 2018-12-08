using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadLookAt : MonoBehaviour {

    public GameObject target;
    private Vector3 targetPoint;
    private Quaternion targetRotation;

    // Use this for initialization
    void Start ()
    {
        target = GameObject.FindWithTag("Player");
    }
	
	// Update is called once per frame
	void Update ()
    {
        targetPoint = new Vector3(target.transform.position.x, transform.position.y, target.transform.position.z) - transform.position;
        targetRotation = Quaternion.LookRotation(-targetPoint, Vector3.up);
        transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 2.0f);
    }
}
