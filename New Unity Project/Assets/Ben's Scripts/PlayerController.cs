using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{



    private CharacterController playerController;
    private Vector3 playerMove;
    public Animator anim; //Used to control the player's animations

    public static float speed = 8.0f; //how fast we want the player to move
    private float sideSpeed = 4.0f; //Controls how fast we move left to right
    private float gravity = 0.0f;
    private float falling = 12.0f;
    private float jumpPower = 1.0f;

    private int jump; //will be 1 for jumping, -1 for not jumping
    private float iJumpTime;

    // Use this for initialization
    void Start()
    {
        playerController = GetComponent<CharacterController>();
        anim = GetComponent<Animator>();
    }

    // Update is called once per frame
    void Update()
    {

        CheckIfGameEnded(); //checks if game ended for any reason
        RotatePlayer(); //Rotates player
        KeyPress("Space_Pressed", "space"); //Checks to see if the player jumps

        PlayerJump();

        //X
        //Make sure the player can only move along the x axis a certain amount
        playerMove.x = Input.GetAxisRaw("Horizontal") * sideSpeed;

        if (Input.GetKeyDown(KeyCode.Space))
            anim.SetTrigger("Jump_Pressed");

        /*
        //Y
        //if I'm grounded and I press space
        if (Input.GetKey(KeyCode.Space) && playerController.isGrounded)
        {
            jump = 1;
        }

        //If I'm grounded and currently dropping
        if (playerController.isGrounded && jump == 0) //if the player is on the floor
        {
            gravity = -0.5f;
        }

        if (jump == 0) //no jump 
        {
            transform.Rotate(Vector3.up * 0);
            gravity -= falling * Time.deltaTime * 4;

        }
        if (jump == 1) //with jump
        {
            gravity += falling * Time.deltaTime * 2;

        }
        playerMove.y = gravity;
        */
        //Z
        playerMove.z = transform.forward.z * speed; //Constantly moves us forward
        
        //Rotates the player
        float mouseInput = Input.GetAxis("Mouse X");
        Vector3 lookhere = new Vector3(0, mouseInput, 0);
        transform.Rotate(lookhere);

        playerController.Move(playerMove * Time.deltaTime);
    }

    //Handles the player's jump
    private void PlayerJump()
    {
       

    }
    public void KeyPress(string animEffected, string key)
    {
        if (Input.GetKeyDown(key))
        {
            anim.SetBool(animEffected, true);
        }
        if (Input.GetKeyUp(key))
        {
            anim.SetBool(animEffected, false);
        }
    }


    void OnCollisionEnter(Collision collision)
    {
        // print("Hello\n");
        if (collision.gameObject.tag == "Arrow")
        {
            speed += 2.0f;
            print("Hello");
        }
        playerMove.z = 0.0f;
    }


    //Rotates player based on mouse movement
    public void RotatePlayer()
    {
        Ray ray = Camera.main.ScreenPointToRay(Input.mousePosition);
        Plane plane = new Plane(Vector3.up, Vector3.zero);
        float distance;
        if (plane.Raycast(ray, out distance))
        {
            Vector3 target = ray.GetPoint(distance);
            Vector3 direction = target - transform.position;
            float rotation = Mathf.Atan2(direction.x, direction.z) * Mathf.Rad2Deg;
            transform.rotation = Quaternion.Euler(0, rotation, 0);
        }
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

