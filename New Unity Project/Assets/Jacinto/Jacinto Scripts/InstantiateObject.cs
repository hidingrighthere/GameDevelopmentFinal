using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InstantiateObject : MonoBehaviour {
    public int zSpace = 2;
    public int instanceOf = 5;
    public GameObject candyCane;
	// Use this for initialization
	void Start () {
        for(int index = 0; index < this.instanceOf; index++)
        {
            Debug.Log("In Loop");
            GameObject game = this.candyCane;
            game.GetComponent<InstantiateObject>().enabled = false;
            game.transform.position = new Vector3(this.transform.position.x, this.transform.position.y, this.transform.position.z + 2);
            GameObject.Instantiate(game);
        }
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
