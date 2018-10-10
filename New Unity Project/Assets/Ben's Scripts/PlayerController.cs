using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    private CharacterController playerController;

    private float speed = 8.0f; //how fast we want the player to move
    private float gravity = 0.0f;
    private float falling = 12.0f;
    private float jumpPower = 1.0f;
    private int jump; //will be 1 for jumping, -1 for not jumping
    private float iJumpTime;
    private Vector3 playerMove;


    private float score = 0.0f;
    private float Level = 0.0f;
    private float multiply = 1;

    int pastLevel;
    int LevelWait;
    // Use this for initialization
    void Start()
    {
        pastLevel = 0;
        LevelWait = 0;
        playerController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        playerMove = Vector3.zero;

        gravity -= falling * Time.deltaTime * 4;

        playerMove.y = gravity;

        playerController.Move(playerMove * Time.deltaTime);
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

    public void StartPowerup(int i)
    {
        print("powerup received \n" + i);
        if (i == 1) //speed powerup
            this.speed += 1.0f;
        if (i == 2) //jump powerup
            this.jumpPower += 0.1f;
        if (i == 3) //Multiply PowerUp
            this.multiply += 0.5f;
    }


}
