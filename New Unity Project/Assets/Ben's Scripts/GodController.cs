﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GodController : MonoBehaviour {


    private Transform Player;
    private Vector3 start;
    public int iX, iY, iZ;
    // Use this for initialization
    void Start()
    {
        Player = GameObject.FindGameObjectWithTag("Player").transform;
        //     start = transform.position - Player.position;

    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector3(iX, iY, Player.position.z + iZ);
        //   transform.position = Player.position;
    }
}
