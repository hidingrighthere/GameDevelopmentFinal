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
    private Vector3 RBase_UpperArm = new Vector3(54.59f, 38, 103);
    private Vector3 RAwake_UpperArm = new Vector3(54.59f, 98, 200);
    private Vector3 LBase_UpperArm = new Vector3(-50, -38, 103);
    private Vector3 LAwake_UpperArm = new Vector3(-50 -95, 190);

    //If parameters used to determine what to do
    private int CurrArm; //0 for left arm, 1 for right arm


    private static bool Spawn = true; //if true, spawn in a new material

    public float speed = 1.0f;
    

	// Use this for initialization
	void Start ()
    {
        mat = GetComponent<Renderer>().material;
        //Set up arm rotation array
        vArray[0] = RBase_UpperArm;
        vArray[1] = LBase_UpperArm;
        vArray[2] = RAwake_UpperArm;
        vArray[3] = LAwake_UpperArm;
        //Set up arm object array
        aArms[0] = RArm;
        aArms[1] = LArm;
    }
	
	// Update is called once per frame
	void Update ()
    {
        if(Spawn)
        {
            Debug.Log("Try Moving Arm");
            CurrArm = (int)Random.Range(0f, 1f); //Choose a random number between 0 and 1
            Debug.Log(CurrArm);
            CurrArm = 0;
            currObject = LArm;  //Set the gameobject
                                //begin moving to spawn animation


            currObject.transform.rotation = Quaternion.Euler(vArray[CurrArm + 2]);
            Vector3 to = vArray[CurrArm + 2];
            Instantiate(create, transform.position, Quaternion.identity);

            //Create the level piece
            Instantiate(level[currItem], transform.position, Quaternion.identity);
            Spawn = false;
            /*
            if (Vector3.Distance(currObject.transform.eulerAngles, to) > 0.01f)
            {
                currObject.transform.eulerAngles = Vector3.Lerp(currObject.transform.rotation.eulerAngles, to, Time.deltaTime * speed);
            }
            else //Once we reach the location to instantiate 
            {
                currObject.transform.eulerAngles = to;
                //explosion for the object

            }*/
        }
        else if(!Spawn)
        {
            /*
            Vector3 to = vArray[CurrArm];
            if (Vector3.Distance(currObject.transform.eulerAngles, to) > 0.01f)
            {
                currObject.transform.eulerAngles = Vector3.Lerp(currObject.transform.rotation.eulerAngles, to, Time.deltaTime * speed);
            }
            else //Once we reach the location to instantiate 
            {
                currObject.transform.eulerAngles = to;
                //explosion for the object
                //Instantiate(create, transform.position, Quaternion.identity);

                //Create the level piece
                //Instantiate(level[currItem], transform.position, Quaternion.identity);
                //Spawn = false;
            }*/
        }

 //       mat.SetFloat("_DissolveAmount", Mathf.Sin(Time.time) / 2 + 0.5f);	

	}
}
