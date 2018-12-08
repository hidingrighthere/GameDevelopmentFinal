using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {


    private Transform Player;
    private Vector3 start;
    private Animator anim;      //Used to control the God animations
    public int iX, iY, iZ;

    public AudioClip[] clips;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        anim = GetComponent<Animator>();
        //     start = transform.position - Player.position;

    }

    // Update is called once per frame
    void Update()
    {
        GodKeys();
        transform.position = new Vector3(iX, iY, Player.position.z + iZ);
        //   transform.position = Player.position;
    }


    void GodKeys()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.G))
        {
            anim.SetTrigger("Gravity");
            audio.clip = clips[0];
            audio.Play();
        }
    }
}
