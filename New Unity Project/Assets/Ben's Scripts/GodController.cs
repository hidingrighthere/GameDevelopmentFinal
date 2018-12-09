using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {


    private Transform Player;
    private Vector3 start;
    private Animator anim;      //Used to control the God animations
    public int iX, iY, iZ;

    public float bpm = 120; //beat per minute for him to nod to
    public AudioClip[] clips;

    public AudioSource music;

    private float lastTime, deltaTime, timer;

    private int counter = 1;

    //Used to move the skeleton
    private Vector3 playerMove = Vector3.zero; 

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        // anim = GetComponent<Animator>();
        lastTime = 0.0f;
        deltaTime = 0.0f;
        timer = 0.0f;


    }

    // Update is called once per frame
    void Update()
    {

        GodKeys();
       // Debug.Log("Enter Skeleton Update " + GetComponent<AudioSource>().time);
        deltaTime = GetComponent<AudioSource>().time - lastTime;
        timer += deltaTime;

        Debug.Log("Timer = " + timer + " vs BPM = " + (60f/bpm));
        //On the beat do something
        if(timer >= (60f/bpm))
        {

            transform.position += transform.up * counter;
            Debug.Log("Test");
            counter = counter * -1;
            timer = 0;
        }
        else
        {
            transform.position = new Vector3(iX, transform.position.y, Player.position.z + iZ);
        }



        lastTime = GetComponent<AudioSource>().time;
    }


    void GodKeys()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("Gravity");
     //       audio.clip = clips[0];
       //     audio.Play();
        }
    }
}
