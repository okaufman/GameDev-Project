using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LazerController : MonoBehaviour {
    public int speed = 20;
   

	// Use this for initialization
	void Start () {
        GetComponent<Rigidbody>().velocity = transform.right * speed;
	}

    private void OnCollisionEnter()
    {
        print("DEstroyed");
        Destroy(gameObject);
    }


}
