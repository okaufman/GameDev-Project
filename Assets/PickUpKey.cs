using System.Collections;
using System.Collections.Generic;
using UnityEngine;


public class PickUpKey : MonoBehaviour {

    private AnimationCurve animationCurve;
    private float upDownSpeed = 1f;
   


    void Start () {
		
	}
	
	void Update () {

    }

    private void OnCollisionEnter(Collision collision) {
        if (collision.gameObject.tag == "Player" || collision.gameObject.tag=="redPlayer" || collision.gameObject.tag == "bluePlayer") {
            UIKeys.KeysFound++;
            
            Destroy(gameObject);
            
           
        }
    }

   
}
