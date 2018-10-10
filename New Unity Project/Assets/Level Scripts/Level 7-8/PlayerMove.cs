using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour {


    public GameObject player;
    public GameObject cam;
    int speed = 10;
    public int jumpSpeed = 20;
    Animator anim;
    float isGround = -1f;
    bool isJumping;
    int jumpCount = 0;


	// Use this for initialization
	void Start () {

        this.isJumping = false;
        this.anim = gameObject.GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

        this.player.transform.position += Vector3.forward * Time.deltaTime * speed;
        Vector3 tempPos = new Vector3(this.cam.transform.position.x, this.cam.transform.position.y, player.transform.position.z);
        this.cam.transform.position = tempPos;
        //Debug.Log("The Z: " + this.cam.transform.position.z);

        if (Input.GetKey(KeyCode.Space))
        {
            if (Input.GetKeyDown(KeyCode.Space))
            {
                this.jumpCount = 1;
            }
            //this.isGround = this.player.transform.position.y;
            //anim.SetTrigger("isJump");
            if (this.isJumping == false && jumpCount == 1)
            {
                anim.SetBool("isJumping", true);
                this.isJumping = true;
            }
            this.player.transform.position += Vector3.up * Time.deltaTime * jumpSpeed;
            
            
        }

       
    }


    void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.tag.Equals("Platform"))
        {
            if (this.isJumping == true) {
                Debug.Log("Hits the floor. ");
                anim.SetBool("isJumping", false);
                this.isJumping = false;
                this.jumpCount = 0; 
            }
        }
    }

    /*
     * GameObject player;
    Transform playerTran;
    public int Speed = 200;
    public int digSpeed = 100;
    public Camera mainCam;
    enum Dir {LEFT,CENTER,RIGHT};
    Dir playerDir = Dir.CENTER;
    Vector3 centerPos,leftPos,rightPos;
    Vector3 CamCam;
    Animator anim;

    // Use this for initialization
    void Start () {

        this.player = GameObject.FindGameObjectWithTag("Player");
        Debug.Log("Player position:: " + this.player.transform.position.x + "," + this.player.transform.position.y + "," + this.player.transform.position.z);
        this.playerTran = this.GetComponent<Transform>();
        this.centerPos = this.playerTran.position;
        this.CamCam = this.mainCam.transform.position;
        this.anim = GameObject.FindGameObjectWithTag("Player").GetComponent<Animator>();
       // this.leftPos = new Vector3(-.5f, this.playerTran.position.y, this.playerTran.position.z);
        //this.rightPos = new Vector3(.5f, .5f, 0);
	}

   
    // Update is called once per frame
    void Update () {

        if (Input.GetKey(KeyCode.A) /*&& playerDir != Dir.LEFT*)
        {
            //Debug.Log("Pressed left: " + this.playerTran.position.x);
            // this.playerTran.Translate((this.playerTran.position.x - .5f,this.playerTran.position.y,this.playerTran.position.z);
            //this.playerTran.Translate((Vector3.left*Time.deltaTime)* digSpeed);
            this.playerTran.position += Vector3.left* Time.deltaTime * digSpeed;
            this.mainCam.transform.position.x.Equals(this.playerTran.position.x);
            if (this.mainCam.transform.position.x >= -.9f)
            {
        this.mainCam.transform.position += Vector3.left * Time.deltaTime * digSpeed;
    }
            this.playerDir = Dir.LEFT;
    }
        else if(Input.GetKey(KeyCode.D) /*&& playerDir != Dir.RIGHT*)
        {
            //Debug.Log("Pressed right: " + this.playerTran.position.x);
            this.playerTran.position += Vector3.right* Time.deltaTime * digSpeed;
       
            this.mainCam.transform.position.x.Equals(this.playerTran.position.x);
            if (this.mainCam.transform.position.x< .9f)
            {
        this.mainCam.transform.position += Vector3.right * Time.deltaTime * digSpeed;
    }
            //this.mainCam.transform.position += Vector3.right * Time.deltaTime * digSpeed;
            //this.playerTran.Translate((Vector3.right * Time.deltaTime) * digSpeed);
            this.playerDir = Dir.RIGHT;
    }else if (Input.GetKey(KeyCode.S))
        {
            this.playerTran.position += Vector3.down* Time.deltaTime * digSpeed;

}
        this.player.transform.position += (Vector3.forward* Speed * Time.deltaTime)+ (Vector3.forward * Speed * Time.deltaTime);
        this.mainCam.transform.position += (Vector3.forward * Speed * Time.deltaTime) + (Vector3.forward * Speed * Time.deltaTime);
// Debug.Log("Player position: "+this.playerTran.position.z);
}*/


}
