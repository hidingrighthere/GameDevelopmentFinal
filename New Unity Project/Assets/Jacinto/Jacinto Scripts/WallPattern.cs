using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class WallPattern : MonoBehaviour {

    public GameObject[] list = new GameObject[1];

    public float distanceApart;

    public int numOfCreations = 3;
    GameObject currentObj;
    GameObject lastObj;


	// Use this for initialization
	void Start () {

        // this.startNum = ((this.platform.transform.position.x / 2) - 2);
        //this.list = new GameObject[genSize];
        //Debug.Log("Length is: " + this.ShapeGen.transform.position);

        //this.ShapeGen.transform.position = new Vector3(this.platform.transform.position.x - this.StartingIndexForSnakePattern, this.ShapeGen.transform.position.y, this.ShapeGen.transform.position.z);

        ///this.list[0] = this.ShapeGen;



        this.currentObj = this.gameObject;
        
       
        for (int i = 0; i < this.numOfCreations; i++)
        {
            int randVal = Random.Range(0, (this.list.Length-1));
            this.lastObj = currentObj;
            this.currentObj = this.list[randVal];

            if (i > 0)
            {
                //this.list[i] = this.list[i - 1];
                if (this.gameObject.name.Equals("WallPuz"))
                this.list[i].GetComponent<WallPattern>().enabled = false;

                Vector3 ls = this.lastObj.transform.position;




                this.currentObj.transform.position = new Vector3(ls.x, ls.y, ls.z + this.distanceApart);
                GameObject.Instantiate(this.lastObj);

            }
        }
    }

    void OnTriggerEnter(Collider col)
    {
        // player enters rises the platform. 
    }
    // Update is called once per frame
    void Update () {
		
	}

    void moveSkywards()
    {
        // move the platform up. 
    }
}
