using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class pickUpHeart : MonoBehaviour {

	void Start () {
		
	}
	
	void Update () {
		
	}

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player") {
            Destroy(gameObject);
            Player.health += 50;
        }
        if (collision.gameObject.tag == "redPlayer") {
            Destroy(gameObject);
            PlayerRed.health += 50;
        }
        if (collision.gameObject.tag == "bluePlayer") {
            Destroy(gameObject);
            PlayerBlue.health += 50;
        }
    }
}
