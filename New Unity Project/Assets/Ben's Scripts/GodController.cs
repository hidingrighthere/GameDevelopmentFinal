using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {


    private Transform Player;
    private Vector3 start;

    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //     start = transform.position - Player.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(Player.position.x-1, Player.position.y + 3, Player.position.z + 40);
        //   transform.position = Player.position;
    }
}
