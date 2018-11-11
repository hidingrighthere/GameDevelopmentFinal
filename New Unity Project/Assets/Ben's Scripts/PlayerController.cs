using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{



    private CharacterController playerController;
    private Vector3 playerMove; //Used to move the player around
    private Animator anim;      //Used to control the player's animations
    public GameObject FireWings; //Fire Wings

    public static float speed = 8.0f; //how fast we want the player to move
    public  float jumpForce; //How strong we want the jump to be



    private float sideSpeed = 4.0f; //Controls how fast we move left to right
    private static float gravity = 5.0f; //Controls the gravity
    private float falling = 12.0f;
    private float jumpPower = 1.0f;


    private int jump; //will be 1 for jumping, -1 for not jumping


    private float iJumpTime;

    //Powerups
    private bool bGrounded; //Used to determine if a land trigger should be called
    private bool ReverseGravity; //Reverses the gravity
    private bool flight; //Allows flight controls

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
        bGrounded = true;
        ReverseGravity = false;
        flight = false;
    }

    // Update is called once per frame
    void Update()
    {
        TestPowerups(); //Test powerups based on key clicks
        HandleControls();

        Vector3 test = new Vector3(0, 5, 0);
        //if not grounded, don't do anything
        if (!bGrounded)
        {

            if(ReverseGravity)
                playerMove.y += 1;
            else
                playerMove.y -= 1;


            CheckForReverseGravity();
        }


        playerController.Move(playerMove * Time.deltaTime);

    }

    //Handles controls when specific events occur
    private void HandleControls()
    {
        //Used to get rid of some of the force when going up and down
        int iPrevKey = 0;

        //Handles flight
        if(flight)
        {
            playerMove.y = Input.GetAxisRaw("Vertical") * sideSpeed;
           

            playerMove.x = Input.GetAxisRaw("Horizontal") * sideSpeed;

        }

        //Running
        else if(bGrounded)
        {

            CheckIfGameEnded(); //checks if game ended for any reason
            //CheckForReverseGravity();

            if (Input.GetKeyDown(KeyCode.Space))
            {
                GetComponent<Rigidbody>().AddForce(Vector3.up * jumpForce);
                anim.SetTrigger("Jump");
            }


            //X
            //Make sure the player can only move along the x axis a certain amount
            playerMove.x = Input.GetAxisRaw("Horizontal") * sideSpeed;

            //Y

            //Z
            playerMove.z = transform.forward.z * speed; //Constantly moves us forward

            //Rotates the player
            //RotatePlayer();
        }
        playerController.Move(playerMove * Time.deltaTime);

    }
    //Tests powerups, used only for debugging
    private void TestPowerups()
    {
        //If g is press !ReverseGravity
        if(Input.GetKeyDown(KeyCode.G))
        {
            GetComponent<Rigidbody>().useGravity = !GetComponent<Rigidbody>().useGravity; //Removes graity
            ReverseGravity = !(ReverseGravity); //Reverse
            Debug.Log("Reverse gravity is now" + ReverseGravity);
            bGrounded = false;
        
            anim.SetTrigger("Fall");
            if (ReverseGravity)
                playerMove.y = 3;
            else
                playerMove.y = -3;
            playerController.Move(playerMove);
        }

        //If Y is pressed, change the speed
        if(Input.GetKeyDown(KeyCode.Y))
        {
            speed += 50;
        }
        //If Y is pressed, change the speed
        if (Input.GetKeyDown(KeyCode.F))
        {
            GetComponent<Rigidbody>().useGravity = false; //Get rid of gravity
            anim.SetTrigger("Fly");
            Instantiate(FireWings);
            flight = true;

        }

    }
    //Handles the player's jump
    private void PlayerJump()
    {


    }
    //Reverses gravity
    private void CheckForReverseGravity()
    {

        // Vector3 lookhere = new Vector3(transform.rotation.x - 10, 0, 0);
        //Will change x to -180 and y to 180
        if (ReverseGravity == true)
        {
            if(transform.localEulerAngles.z != 180)
                transform.Rotate(0, 0, 180);

        }

        //Will change x back to 0 and y back to 0
        else if (ReverseGravity == false)
        {
            if (transform.localEulerAngles.z != 0)
                transform.Rotate(0, 0, -(transform.localEulerAngles.z));
        }


    }

    //Handles forms of collisions
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        GameObject collision = hit.gameObject;
        if (!bGrounded)
        {
            Debug.Log("CHANGING GROUNDED TO TRUE");
            bGrounded = true;
            anim.SetTrigger("Fall_Land");
        }
        //Start Flying
        if (collision.gameObject.tag == "StartFly")
        {
            Instantiate(FireWings);
        }

        //End Flying
        if(collision.gameObject.tag == "EndFly")
        {
            Destroy(FireWings);
        }
        //Gravity reversal
        if(collision.gameObject.tag == "ReverseGravity")
        {

        }

        //invisible platform jump
        if(collision.gameObject.tag == "InvisJump")
        {

        }
        playerMove.z = 0.0f;
    }










    //Rotates player based on mouse movement
    public void RotatePlayer()
    {

        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);
    }

        public void CheckIfGameEnded()
    {
        if (playerMove.y < -50)
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void Death()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().name);
    }
    

}

