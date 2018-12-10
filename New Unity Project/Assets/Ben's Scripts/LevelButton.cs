using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelButton : MonoBehaviour {
    public void clickButton(int iClicked)
    {
        switch (iClicked)
        {
            case 1:
                SceneManager.LoadScene(sceneName: "Level1");
                break;
            case 2:
                SceneManager.LoadScene("Level2");
                break;
            case 3:
                SceneManager.LoadScene("LevelTest");
                break;
            case 4:
                SceneManager.LoadScene("Level4");
                break;
            case 5:
                SceneManager.LoadScene("Level5");
                break;
            case 6:
                SceneManager.LoadScene("Level6");
                break;
            case 7:
                SceneManager.LoadScene("Level7");
                break;
            case 8:
                SceneManager.LoadScene("Level8");
                break;
        }

    }

    
}


