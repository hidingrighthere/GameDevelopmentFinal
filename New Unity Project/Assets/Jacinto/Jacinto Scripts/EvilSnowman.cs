using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EvilSnowman : MonoBehaviour {
    public GameObject[] SpawnPoints = new GameObject[3];
    public GameObject spawnObject;
    static List<GameObject> move = new List<GameObject>();

     bool isAttack = false;
	// Use this for initialization
	void Start () {
        StartCoroutine(Attack());
	}
	
    public static List<GameObject> getMoveList()
    {
        return move;
    }
	// Update is called once per frame
	void Update () {
        if (isAttack)
        {
            LightItUP();
            isAttack = false;
        }
        moveObject();
	}

    void LightItUP()
    {
        GameObject spawn = this.SpawnPoints[Random.Range(0, this.SpawnPoints.Length)];
        GameObject g = this.spawnObject;
        g.transform.position = spawn.transform.position;
       
        move.Add(GameObject.Instantiate(g));
        
    }

    void moveObject()
    {
        foreach(GameObject obj in move)
        {
            obj.transform.position -= (Vector3.forward * 20f * Time.deltaTime) + (Vector3.forward * 20f * Time.deltaTime);
        }
    }


    private void OnTriggerEnter(Collider col)
    {
        if (col.gameObject.CompareTag("Player"))
        {
            // startCourtine()
        }else if (col.gameObject.CompareTag("AttackPropEnd"))
        {
           
        }
    }

    IEnumerator Attack()
    {
        while (true)
        {
            yield return new WaitForSeconds(3);
            isAttack = true;
        }
    }
}
