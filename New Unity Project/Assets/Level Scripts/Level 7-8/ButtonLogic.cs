using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ButtonLogic : MonoBehaviour {

    public Button AdvanceRetry;
    public Button menu;

	// Use this for initialization
	void Start () {
		


	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnAdvanceRetry()
    {
        //static varible to determine level;
        if(LevelScript.level == 1)
        {

        }else if (LevelScript.level == 2)
        {

        }else if (LevelScript.level == 3)
        {

        }else if (LevelScript.level == 4)
      {

        }else if (LevelScript.level == 5)
        { 

        }else if (LevelScript.level == 6)
        {

        }else if (LevelScript.level == 7)
        {

        }else if (LevelScript.level == 8)
        {

        }
    }

    void OnMenuClick()
    {
        // Load menu
    }
}
