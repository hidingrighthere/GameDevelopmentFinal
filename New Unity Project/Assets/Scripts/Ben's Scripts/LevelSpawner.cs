using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelSpawner : MonoBehaviour
{
    public GameObject[] level; //All the levels that need to be spawned
    private int currItem = 0;
    public GameObject create; //Partical system for creation

    //Objects dealing with the arms
    public GameObject LArm;
    public GameObject RArm;
    private GameObject[] aArms = new GameObject[2];
    private GameObject currObject;

    public Shader shadeCreate;
    Material mat;

    //Vectors for the hand spawning
    private Vector3[] vArray = new Vector3[4];
    private Vector3 RBase_UpperArm = new Vector3(54, 38, 103);
    private Vector3 LBase_UpperArm = new Vector3(-50, -38, 103);
    private Vector3 RAwake_UpperArm = new Vector3(54, 98, 200);
    private Vector3 LAwake_UpperArm = new Vector3(-50 -95, 190);

    
    //If parameters used to determine what to do
    private int CurrArm; //0 for left arm, 1 for right arm

    //Time parameters
    private float fStartTime; //Start Time
    public float fTime = 4; //How long we want the animation to go for
    private float t;

    private static bool Spawn = true; //if true, spawn in a new material

    public float speed = 1.0f;
    

	// Use this for initialization
	void Start ()
    {
        //Set up arm rotation array
        vArray[0] = RBase_UpperArm;
        vArray[1] = LBase_UpperArm;
        vArray[2] = RAwake_UpperArm;
        vArray[3] = LAwake_UpperArm;
        //Set up arm object array
        aArms[0] = GameObject.FindGameObjectWithTag("RightArm");
        aArms[1] = GameObject.FindGameObjectWithTag("LeftArm");
        
        fStartTime = Time.deltaTime; 
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Spawn)
        {

            t += Time.deltaTime / fTime;

            CurrArm = 0;
            currObject = aArms[CurrArm];
            Vector3 to = vArray[CurrArm + 2];
            Quaternion target = Quaternion.Euler(to);
           
            if (Vector3.Distance(currObject.transform.eulerAngles, to) >= 0.01f)
            {

                Debug.Log("Move " + Vector3.Distance(currObject.transform.eulerAngles, to));
                currObject.transform.localRotation = Quaternion.Slerp(currObject.transform.localRotation, target, speed);
            }
            else //Once we reach the location to instantiate 
            {
                Debug.Log("Time");
                //  currObject.transform.rotation = new Quaternion(to);
                currObject.transform.eulerAngles = to;
                
                //explosion for the object
                Instantiate(create, transform.position, Quaternion.identity);

                //Create the level piece
                Instantiate(level[currItem], transform.position, Quaternion.identity);
                Spawn = false;
                t = 0;
            }
        }
        else if(!Spawn)
        {
            t += Time.deltaTime / fTime;
            Vector3 to = vArray[CurrArm];
            Quaternion target = Quaternion.Euler(vArray[CurrArm]);
            if (Vector3.Distance(currObject.transform.eulerAngles, to) >= 0.01f && t <= fTime)
            {
                Debug.Log("Reset");
                currObject.transform.localRotation = Quaternion.Slerp(currObject.transform.localRotation, target, t);
            }
            else //Once we reach the location to instantiate 
            {
                Debug.Log("Set");
                currObject.transform.eulerAngles = to;
            }
        }

 //       mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);	

	}
}
