using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {


    private Transform Player;

    private GameObject Head;
    private ParticleSystem Heart;
    private Vector3 start;
    private Animator anim;      //Used to control the God animations
    public int iX, iY, iZ;

    private float t;


    public static GameObject currObject; //Current spawning gameobject


    public float bpm = 120; //beat per minute for him to nod to
    public AudioClip[] clips;

    public AudioSource music;

    private float lastTime, deltaTime, timer;

    private int counter = 1;

    private int iChoose = 0; //0 move by x, 1 by y, 2 by z


    public GameObject[] level; //All the levels that need to be spawned

    private int currItem = 0;
    public Vector3 target;

    //Used to move the skeleton
    private Vector3 playerMove = Vector3.zero; 

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        Head = GameObject.FindGameObjectWithTag("GodHead");
        Heart = GameObject.FindGameObjectWithTag("HeartLight").GetComponent<ParticleSystem>(); 
        target = new Vector3(Player.position.x, Player.position.y + 10, Player.position.z);

        lastTime = 0.0f;
        deltaTime = 0.0f;
        timer = 0.0f;
        t = 0;


    }

    // Update is called once per frame
    void Update()
    {

        GodKeys();
       // Debug.Log("Enter Skeleton Update " + GetComponent<AudioSource>().time);
        deltaTime = GetComponent<AudioSource>().time - lastTime;
        timer += deltaTime;


        //On the beat do something
        if (timer >= (60f/bpm))
        {
            //iY += counter;
            //transform.position = new Vector3(iX, iY + counter, Player.position.z + iZ);

            Vector3 to = new Vector3(Player.position.x, Player.position.y, Player.position.z + iZ);
            Vector3 from = new Vector3(Player.position.x + 15, Player.position.y, Player.position.z + iZ);
            currObject = Instantiate(level[currItem], from, Quaternion.identity) as GameObject;
            currObject.GetComponent<CreateLevel>().target = to;
            currObject.GetComponent<CreateLevel>().bpm = bpm;

            //Increase Heart Size and light based on beat
            var Light = Heart.lights;
            Light.maxLights += counter * 5;
            counter = counter * -1;

            timer = 1/60f;
            Head.transform.localPosition = new Vector3(Head.transform.localPosition.x , Head.transform.localPosition.y + (float)(counter * 2) / 1000, Head.transform.localPosition.z);
        }
        else
        {

            transform.position = new Vector3(iX, iY, Player.position.z + iZ);
            Head.transform.localPosition = new Vector3(Head.transform.localPosition.x , Head.transform.localPosition.y, Head.transform.localPosition.z);

        }



        lastTime = GetComponent<AudioSource>().time;
    }


    void GodKeys()
    {
        AudioSource audio = GetComponent<AudioSource>();

        if (Input.GetKeyDown(KeyCode.G))
        {
     //       audio.clip = clips[0];
       //     audio.Play();
        }
    }

    //Move to the position x in the
    IEnumerator MoveTarget()
    {
      
        Debug.Log("MoveTarget");
        t += Time.deltaTime / 60f/bpm;
        currObject.transform.position = Vector3.Lerp(currObject.transform.position ,target, t);
        yield return new WaitForFixedUpdate();         // Leave the routine and return here in the next fram
    }


}
