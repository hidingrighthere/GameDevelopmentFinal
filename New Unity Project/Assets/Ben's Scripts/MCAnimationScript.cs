using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnimationScript : MonoBehaviour {

    public bool jump;
    public bool run;
    public bool fly;

    public Animator anim;
    private Transform Player;

    private CharacterController playerController;

    int iTurn = 20; //COntrols  how well the user can turn

    // Use this for initialization
    void Start ()
    {
        Player = GameObject.FindGameObjectWithTag("Player2").transform;
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {
        
        //Jump
        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("jumpTrigger");
        }

        if (Input.GetKeyUp("space"))
            transform.Rotate(Vector3.up * 0);

        //Move to the left
        if(Input.GetKey(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * iTurn);
            // ...also rotate around the World's Y axis
            //transform.Rotate(Vector3.left * Time.deltaTime, Space.World);
            anim.SetBool("Key_Left", true);
        }

        if(Input.GetKeyUp(KeyCode.RightArrow))
        {
            transform.Rotate(Vector3.up * 0);
            anim.SetBool("Key_Left", false);
        }

        //Move to the right
        if (Input.GetKey(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * Time.deltaTime * iTurn * -1);
            anim.SetBool("Key_Right", true);
        }
    
        if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            transform.Rotate(Vector3.up * 0);
            anim.SetBool("Key_Right", false);
        }
    }
}
