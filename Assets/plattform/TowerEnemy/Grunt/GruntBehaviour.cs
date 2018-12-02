using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GruntBehaviour : MonoBehaviour {
    public float speed = 4.0F;
    public Rigidbody myBody;
    public Transform myTransform;
    public Transform firePoint;
    public Rigidbody smallBullet;
    public Transform Player;
    public float nextFire = 0.0F;
    public float fireRate = 1;
    public int attackRange = 2;
    // private Vector3 moveDirection = Vector3.zero;

    // Use this for initialization
    void Start () {
       myBody= this.GetComponent <Rigidbody>();
       myTransform = this.transform;

	}

    private void Update()
    {
        if ((Vector3.Distance(firePoint.position, Player.position) < attackRange))
        {
            if (Time.time > nextFire)
            {

                    Shoot(firePoint);
                    nextFire = Time.time + fireRate;

            }
        }
    }

    // Update is called before Rendering
    void FixedUpdate () {
        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTransform.right.x *speed;
        myBody.velocity = myVel;

	}
    
    void OnCollisionEnter(Collision collision)
    {
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

    void Shoot(Transform firePoint)
    {

        firePoint.LookAt(Player);

        Rigidbody Bullet = Instantiate(smallBullet, firePoint.position + firePoint.forward, firePoint.rotation);
        Bullet.AddForce(firePoint.forward * 400);
        //print("fired");
    }


}
