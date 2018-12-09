using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SnakeObs : MonoBehaviour {
    // init shapes
    public GameObject ShapeGen;
    public GameObject platform;
    public int genSize = 10;
    public float offset = 1f;
    GameObject[] list = new GameObject[1];
    public float startNum = 10;
    public float initXShapePadding = 0.0f; // 
    public float StartingIndexForSnakePattern = 2f;

    // Use this for initialization
    void Start () {
        this.startNum = ((this.platform.transform.position.x / 2) -2);
        
        this.list = new GameObject[genSize];
        Debug.Log("Length is: " + this.ShapeGen.transform.position);

        this.ShapeGen.transform.position = new Vector3(this.platform.transform.position.x - this.StartingIndexForSnakePattern, this.ShapeGen.transform.position.y, this.ShapeGen.transform.position.z);

        this.list[0] = this.ShapeGen;

        for (int i = 0; i < this.genSize; i++)
        {
           // Debug.Log(i);
            if (i > 0)
            {
               // this.list[i].transform.position = new Vector3(this.list[i-1].transform.position.x,this.list[i].transform.position.z , this.list[i].transform.position.z);

                this.list[i] = this.list[i - 1];
                this.list[i].GetComponent<SnakeObs>().enabled = false;
                Vector3 ls = this.list[i - 1].transform.position;
                this.list[i].transform.position = new Vector3(ls.x + this.initXShapePadding, ls.y, ls.z + this.offset);
                Debug.Log("Instantiate");
                GameObject.Instantiate(this.list[i]);
            }
        }
        //StartCoroutine("moveObject");
    }

   /*
    void increment()
    {
        if(index >= index)
        {
            index = 0;
        }
        else
        {
            index++;
        }
    }


    IEnumerator moveObject()
    {
        while (true)
        {
            yield return new WaitForSeconds(this.playSpeed);

        
            this.sec += .5f;
        }
    }*/



}
