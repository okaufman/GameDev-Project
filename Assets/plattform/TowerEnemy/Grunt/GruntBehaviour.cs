using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class GruntBehaviour : MonoBehaviour {
    public float speed = 4.0F;
    public Rigidbody myBody;
    public Transform myTransform;
    public Transform firePoint;
    public Rigidbody smallBullet;
    public float nextFire = 0.0F;
    public float fireRate = 1;
    public int attackRange = 2;
    public int Health = 50;

    public AudioSource sound;

    


    // Use this for initialization
    void Start () {
       myBody= this.GetComponent <Rigidbody>();
       myTransform = this.transform;
       
        
	}

    private void Update()
    {
        
            if (Time.time > nextFire)
            {

                    Shoot();
                    nextFire = Time.time + fireRate;

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
        if (collision.gameObject.tag != "EnemyBullet")
        {
            //take damage when hit by bullet
            if (collision.gameObject.tag == "PlayerBullet")
            {
                takeDamage(10);
            }



            switchDirection();
        }

        if (collision.gameObject.tag == "bluePlayer") {
            if (Input.GetKey(KeyCode.Space)) {
                takeDamage(100);
            }
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "redPlayer")
        {
            
            sound.Play();
            beenjumped();
        }
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

    void Shoot()
    {

        //firePoint.LookAt(Player);
        Instantiate(smallBullet, firePoint.position, firePoint.rotation).AddForce(firePoint.right * 800);
        
        //Rigidbody Bullet = Instantiate(smallBullet, firePoint.position , firePoint.rotation);
        //Bullet.AddForce(firePoint.forward * 800);
        //print("fired");
    }

    public void takeDamage(int damage)
    {
        this.Health -= damage;
        //getPoint();
        UIPoints.UIpts += 1;
        if(this.Health<= 0)
        {
            //get10Points();
            UIPoints.UIpts += 10;
            Destroy(gameObject);
           
        }
    }

    public void beenjumped()
    {
        Destroy(gameObject, 0.1f);
        UIPoints.UIpts += 10;
    }

}
