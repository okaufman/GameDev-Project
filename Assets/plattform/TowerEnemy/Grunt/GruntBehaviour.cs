using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour {
    public float speed = 4.0F;
    public Rigidbody myBody;
    public Transform myTransform;
    public Transform FirePoint;
   // private Vector3 moveDirection = Vector3.zero;

	// Use this for initialization
	void Start () {
       myBody= this.GetComponent <Rigidbody>();
       myTransform = this.transform;
    
        
		
	}
	
	// Update is called before Rendering
	void FixedUpdate () {

        

        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTransform.right.x *speed;
        myBody.velocity = myVel;
        
		
	}

    //private void OnTriggerEnter()
    
    void OnCollisionEnter(Collision collision)
    {

        print(collision.contacts);
        foreach (ContactPoint contact in collision.contacts)
        {
            Debug.DrawRay(contact.point, contact.normal, Color.white);
        }

        switchDirection();
        
        
    }

    void switchDirection()
    {   
        //save current rotation
        Vector3 currRot = transform.eulerAngles;
        //change rotation
        currRot.y += 180;
        //assign new Rotation to object
        transform.eulerAngles = currRot;
        
    }

    
}
