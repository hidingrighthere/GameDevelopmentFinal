using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MCAnimationScript : MonoBehaviour {

    public bool jump;
    public bool run;
    public bool fly;

    public Animator anim;


	// Use this for initialization
	void Start ()
    {
        anim = GetComponent<Animator>();
	}

    // Update is called once per frame
    void Update()
    {

        if (Input.GetKeyDown("space"))
        {
            anim.SetTrigger("jumpTrigger");
            //anim.Play("Jump");
            //jump = true;
        }
        if(anim.GetCurrentAnimatorStateInfo(0).IsName("Jump"))
        {
            Debug.Log("ANIMATION CONTINUE!");
            //anim.Play("Run");
        }

    }
}
