using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Destroy : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider collision)
    {
        Debug.Log("Detect");
        if (collision.gameObject.CompareTag("EndGame"))
        {
            Debug.Log("Destroy");
            EvilSnowman.getMoveList().Remove(collision.gameObject);
            Destroy(collision.gameObject);
        }
    }
}
