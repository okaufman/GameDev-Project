﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour {

    public Transform Player;
	
	
	// Update is called once per frame
	void LateUpdate () {

        transform.position = new Vector3(Player.position.x,
                                     Player.position.y,
                                     transform.position.z);

    }
}
