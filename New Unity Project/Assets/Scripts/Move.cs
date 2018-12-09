using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Move : MonoBehaviour {

    bool isLeft = true;
    public GameObject platform;
    float startNum;
    public float updateSide = .4f;

	// Use this for initialization
	void Start () {
        this.startNum = (float)((this.platform.transform.position.x /2 )- 2f);
	}
	
	// Update is called once per frame
	void Update () {
        moveObject();
	}

    void moveObject()
    {
        if (isLeft == true)
        {
            if (this.transform.position.x <= (this.platform.transform.position.x - this.startNum))
            {
                isLeft = false;
                Debug.Log("isLeft");
            }
            this.transform.position += Vector3.left * this.updateSide * Time.deltaTime;
            
        }else if(this.isLeft == false)
         {
             if(this.transform.position.x >= (this.platform.transform.position.x + this.startNum))
             {
                 //Todo: return right and increments
                 this.isLeft = true;
             }
            this.transform.position -= Vector3.left * this.updateSide * Time.deltaTime;
        }
    }
}
