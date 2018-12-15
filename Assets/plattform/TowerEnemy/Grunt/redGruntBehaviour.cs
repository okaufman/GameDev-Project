using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class redGruntBehaviour : MonoBehaviour  {

    public float speed = 4.0F;
    public Rigidbody myBody;
    public Transform myTransform;
    public Transform firePoint;
    public Rigidbody smallBullet;
    public Transform Player;
    public float nextFire = 0.0F;
    public float fireRate = 0.5F;
    public int attackRange = 10;
    public int Health = 80;

    //Event to manage Points the PLayer gets
    // public event Action getPoint = delegate { };
    //public event Action get10Points = delegate { };


    // Use this for initialization
    void Start()
    {
        myBody = this.GetComponent<Rigidbody>();
        myTransform = this.transform;

    }

    private void Update()
    {
        
            if (Time.time > nextFire)
            {

                Shoot(firePoint);
                nextFire = Time.time + fireRate;

            }
        
    }

    // Update is called before Rendering
    void FixedUpdate()
    {
        //Always move forward
        Vector2 myVel = myBody.velocity;
        myVel.x = myTransform.right.x * speed;
        myBody.velocity = myVel;

    }

    void OnCollisionEnter(Collision collision)
    {
        //take damage when hit by bullet
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takeDamage(10);
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

    void Shoot(Transform firePoint)
    {

        Instantiate(smallBullet, firePoint.position, firePoint.rotation).AddForce(firePoint.right * 800);
        //print("fired");
    }

    public void takeDamage(int damage)
    {
        this.Health -= damage;
        //getPoint();
        UIPoints.UIpts += 1;
        if (this.Health <= 0)
        {
            //get10Points();
            UIPoints.UIpts += 20;
            Destroy(gameObject);

        }
    }
}
