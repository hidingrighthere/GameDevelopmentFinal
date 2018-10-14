using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Gen : MonoBehaviour {
    public GameObject[] plats = new GameObject[1];
    public GameObject firstPlat;
    public GameObject player;
    public int playerDist = 20;
    GameObject currentPlat, lastPlat, instObeject;
    //Vector3 newLoc;
    bool isFirst;
    int count;

    // Use this for initialization
    void Start()
    {
        this.player = GameObject.FindGameObjectWithTag("Player");
        count = 0;
        this.isFirst = true;
        this.currentPlat = this.firstPlat;
        this.lastPlat = this.currentPlat;

        // instantiate 3 levels. 
        //last one is stored in last plat. 
    }

    // Update is called once per frame
    void Update()
    {
        if ((this.currentPlat.transform.position.z + this.currentPlat.transform.localScale.z) - this.player.transform.position.z < (this.playerDist))
        {
            //create a random number generator. 
            Debug.Log("The size of array is: "+this.plats.Length);
            this.instObeject = plats[Random.Range(0, this.plats.Length)]; //Random.Range(0,this.plats.Length); // number generator.
            this.instObeject.transform.position = new Vector3(this.currentPlat.transform.position.x, this.currentPlat.transform.position.y, (this.currentPlat.transform.position.z + this.currentPlat.transform.localScale.z));
            lastPlat = currentPlat;
            this.currentPlat = GameObject.Instantiate(instObeject);
            if (this.count == 3)
            {
                this.isFirst = false;
            }
            count++;
        }

      /*  //destory
        if (this.player.transform.position.z > this.lastPlat.transform.position.z && isFirst == false)
        {
            Destroy(this.lastPlat);
            Destroy(this.firstPlat);
        }*/
    }

}
