﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpHeart : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag == "redPlayer" || collision.gameObject.tag == "bluePlayer") {
            Destroy(gameObject);
            UIHealth.health += 50;
        }
    }
}
