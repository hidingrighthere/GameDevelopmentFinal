using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{



    private CharacterController playerController;
    private Vector3 playerMove = Vector3.zero; //Used to move the player around
    public GameObject FireWings; //Fire Wings

    //Powerups
    private bool bGrounded; //Used to determine if a land trigger should be called
    private bool ReverseGravity; //Reverses the gravity
    private bool flight; //Allows flight controls

    //Parameters dealing with the x axis
    public float sideSpeed = 4.0f; //Controls how fast we move left to right


    //Parameters dealing with jumping
    public float jumpHeight; //How high we want to jump
    public float jumpTime = 2f; //How long the jump occurs for
    public float jumpSpeed = 2.0f;
    public float fallMultiplier = 1.0f;
    private float fTime; //Used to compare times

    //Used to calculate current location
    public float currY = 0.0f;
    private float land; //Last landing spot

    //Parameters dealing with the z axis
    public float speed = 8.0f; //how fast we want the player to move

    //Powerup values
    private int gravity = -1;
    private bool reverseGravity; //Tells us when reverse gravity occurs
    private float ZRotate= 180;
    private float rotate;
    private bool rotating = false;
    public float rotateTime = 3f;
    public float rotateSpeed = 0.5f;
    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        bGrounded = true;
        ReverseGravity = false;
        flight = false;
        gravity = 1;
    }

    // Update is called once per frame
    void Update()
    {

        TestPowerups(); //Test powerups based on key clicks

        if(reverseGravity)
        {
            playerMove.y += (1 * gravity * -1)/rotateTime;
            playerController.Move(playerMove * Time.deltaTime);
            
            //Take out later
            float aim = 0;
            if (gravity < 0)
                aim = 180;

            Vector3 to = new Vector3(0, 0, aim);
            if (Vector3.Distance(transform.eulerAngles, to) > 0.01f)
            {
                transform.eulerAngles = Vector3.Lerp(transform.rotation.eulerAngles, to, Time.deltaTime * 4);
            }
            else
            {
                transform.eulerAngles = to;
                reverseGravity = false;
            }
            
        }
        else
        {
            RotatePlayer();
            HandleControls();
        }

    }

    //Handles controls when specific events occur
    private void HandleControls()
    {
        Debug.Log(gravity);
        //Handles flight
        if (flight)
        {
            playerMove.y = Input.GetAxisRaw("Vertical") * sideSpeed;
            playerMove.x = Input.GetAxisRaw("Horizontal") * sideSpeed;
        }

        //Handles jumping
        if(Input.GetKeyDown(KeyCode.Space))
        {
            fTime = Time.time;
        }
        //Jump only when grounded and a jump is not occuring
        if (Input.GetKey(KeyCode.Space) && jumpTime > Time.time - fTime) //when space is pressed
        { 
            playerMove.y = jumpHeight * Mathf.Sin(Mathf.PI * ((Time.time - fTime) / jumpTime)) * gravity;
            Debug.Log("jump");
        }
        else
        {
            playerMove.y = fallMultiplier * gravity * -1; //gravity
        }


        playerMove.z = transform.forward.z; //Constantly moves us forward
        playerMove.x = transform.forward.x * sideSpeed;

        playerController.Move(playerMove * Time.deltaTime);

        currY = transform.position.y; //get my current Y position
    }

    //Tests powerups, used only for debugging
    private void TestPowerups()
    {

        //If g is press !ReverseGravity
        if (Input.GetKeyDown(KeyCode.G))
        {
            reverseGravity = true;
            playerMove.y += 10 * gravity;
            playerController.Move(playerMove);
            gravity = (-1) * gravity; //reverse gravity   
 
        }

        //If Y is pressed, change the speed
        if(Input.GetKeyDown(KeyCode.Y))
        {
            speed += 50;
        }
        //If Y is pressed, change the speed
        if (Input.GetKeyDown(KeyCode.F))
        {
            var createFireWings = Instantiate(FireWings, new Vector3(transform.position.x, transform.position.y, transform.position.z), Quaternion.identity);
            createFireWings.transform.Rotate(90, 0, 0);
            createFireWings.transform.parent = gameObject.transform;
            flight = !flight;

        }

    }


    //Handles forms of collisions
    void OnControllerColliderHit(ControllerColliderHit hit)
    {
        Debug.Log("Test Collision");
        GameObject collision = hit.gameObject;
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
        else
        {
            
            bGrounded = true; //We have collided with something
            land = transform.position.y; //Save the collision
        }
    }

    //Rotates player based on mouse movement
    public void RotatePlayer()
    {

        float mouseInputX = Input.GetAxis("Mouse X");
        float mouseInputY = Input.GetAxis("Mouse Y");

        Vector3 lookhere = new Vector3(0, mouseInputX * sideSpeed, 0);

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

