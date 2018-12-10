using UnityEngine;
using System.Collections;

public class Disappear: MonoBehaviour
{
    public GameObject GameObjectToHide;
    private bool active = false;
    void OnEnable()
    {
        StartCoroutine(ToggleVisibilityCo(GameObjectToHide));
    }
    
    IEnumerator ToggleVisibilityCo(GameObject someObj)
    {
        if (someObj == null) yield break;

        while (true)
        {
            if (active == false)
            {
                someObj.SetActive(active);
                active = true;
                yield return new WaitForSeconds(8.0f);
            } else
            {
                someObj.SetActive(active);
                active = false;
                yield return new WaitForSeconds(8.0f);
            }
            
        }

    }
}