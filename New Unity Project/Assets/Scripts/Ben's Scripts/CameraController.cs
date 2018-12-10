using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{

    private Transform Player;
    private Vector3 start;
    public float iX, iY, iZ; //Used to control the location of the camera

    private int iGravityY; //Used to adjust the camera when gravity reverses
    private bool ReverseGravity;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RotateCamera();
        iGravityY = -1;
        ReverseGravity = false;

    }

    // Update is called once per frame
    void Update()
    {
        //If g is press !ReverseGravity
        if (Input.GetKeyDown(KeyCode.G))
        {

            ReverseGravity = !ReverseGravity;

            if (ReverseGravity == true)
            {
                if (transform.localEulerAngles.z != 180)
                    transform.Rotate(0, 0, 180);
                iGravityY = 1;
            }

            //Will change x back to 0 and y back to 0
            else if (ReverseGravity == false)
            {
                if (transform.localEulerAngles.z != 0)
                    transform.Rotate(0, 0, -180);
                iGravityY = -1;

            }

        }

        transform.position = new Vector3(Player.position.x - iX, Player.position.y + iY * iGravityY, Player.position.z - iZ);
        transform.rotation = Player.transform.rotation;
    }

    //Rotates player based on mouse movement
    public void RotateCamera()
    {

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        Vector3 lookhere = new Vector3(0.0f, mouseInputX, 0.0f);
        transform.Rotate(lookhere);

    }
}
