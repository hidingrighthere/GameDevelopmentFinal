using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Timer : MonoBehaviour {
    // Use this for initialization
    public Text tim;
	void Start () {
        StartCoroutine(timer());
        
	}
	
	// Update is called once per frame
	void Update () {
        tim.text = "Time: " + StaticClass.staticTimer;
	}

    IEnumerator timer()
    {
        while (true)
        {
            yield return new WaitForSeconds(1);
            StaticClass.staticTimer += 1;
        }
    }
}
