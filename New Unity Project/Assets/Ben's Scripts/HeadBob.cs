using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HeadBob : MonoBehaviour {

	// Use this for initialization
	void Start ()
    {
        Debug.Log("transform = " + transform.position.x);
        Debug.Log("Local = " + transform.localPosition.x);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
