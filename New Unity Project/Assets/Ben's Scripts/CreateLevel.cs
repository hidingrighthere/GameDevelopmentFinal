using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CreateLevel : MonoBehaviour
{
    Material dissolve;
    private float currDissolve = 1.0f;
    public Vector3 target;

    public float speed;
    public int iMove; //0 to move to the left of right, 1 to move up or down 

    public float t;
    public float bpm;

    // Use this for initialization
	private void Start ()
    {
        dissolve = GetComponent<Renderer>().material;
        Debug.Log(target);
    }
	
	// Update is called once per frame
	private void Update ()
    {
        float step = speed * Time.deltaTime;
        currDissolve -= Time.deltaTime;
        dissolve.SetFloat("_DissolveAmount", currDissolve);

        t += (Time.deltaTime * 60f/bpm)/2;
        transform.position = Vector3.Lerp(transform.position, target, t);


    }
}
