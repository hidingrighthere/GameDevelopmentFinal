using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformMania : MonoBehaviour {

    public GameObject platform;
    public float updateSide = 0;
    public int startNum = 0;
    bool isLeft;

	// Use this for initialization
	void Start () {
        toggleDir();
        this.isLeft = StaticClass.dirLeft;
	}
	
	// Update is called once per frame
	void Update () {
        if (this.isLeft== true)
        {
            if (this.transform.position.x <= (this.platform.transform.position.x - this.startNum))
            {
               this.isLeft = false;
                Debug.Log("isLeft");
            }
            this.transform.position += Vector3.left * this.updateSide * Time.deltaTime;
        }
        else if (this.isLeft == false)
        {
            if (this.transform.position.x >= (this.platform.transform.position.x + this.startNum))
            {
                //Todo: return right and increments
                this.isLeft = true;
            }
            this.transform.position -= Vector3.left * this.updateSide * Time.deltaTime;
        }
    }

    void toggleDir()
    {
        if (StaticClass.dirLeft == false)
        {
            StaticClass.dirLeft = true;
        }
        else if (StaticClass.dirLeft == true)
        {
            StaticClass.dirLeft = false;
        }
    }
}
