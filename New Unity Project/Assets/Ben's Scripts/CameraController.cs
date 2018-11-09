using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

    private Transform Player;
    private Vector3 start;
    public int iX, iY, iZ; //Used to control the camera

	// Use this for initialization
	void Start () {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
   //     start = transform.position - Player.position;

	}
	
	// Update is called once per frame
	void Update ()
    {
        //Rotates the camera
        //float mouseInput = Input.GetAxis("Mouse X");
        //Vector3 lookhere = new Vector3(0, mouseInput, 0);
        //transform.Rotate(lookhere);

        transform.position = new Vector3(Player.position.x - iX, iY, Player.position.z - iZ);
    }
}
