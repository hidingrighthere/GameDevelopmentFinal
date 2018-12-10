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

    private float sideSpeed;


    public float sensitivityX = 5F;
    public float sensitivityY = 5F;
    public float minimumX = -90F;
    public float maximumX = 90F;
    public float minimumY = -60F;
    public float maximumY = 60F;
    float rotationY = 0F;
    float rotationX = 0f;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        RotateCamera();
        iGravityY = -1;
        ReverseGravity = false;
        sideSpeed = Player.GetComponent<PlayerController>().sideSpeed;
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
        RotateCamera();
    }

    //Rotates player based on mouse movement
    public void RotateCamera()
    {
        rotationX += Input.GetAxis("Mouse X") * sideSpeed;
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);
        rotationY += Input.GetAxis("Mouse Y") * sideSpeed;
        rotationY = Mathf.Clamp(rotationY, minimumY, maximumY);
        transform.localEulerAngles = new Vector3(-rotationY, rotationX, 0);
    }
}
