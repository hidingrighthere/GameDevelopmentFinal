using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class LevelScript : MonoBehaviour {

    public static int level = 1;
    Canvas can;
    Text text;
	// Use this for initialization
	void Start () {
        this.can = gameObject.GetComponent<Canvas>();
        this.text = gameObject.GetComponentInParent<Text>();
		
	}
	
	// Update is called once per frame
	void Update () {
        // change the canvas 
		
	}
}
