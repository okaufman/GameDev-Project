using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;

public class TEnemyGun : MonoBehaviour
{
    public Transform firePointRight;
    public Transform firePointLeft;
    public Rigidbody smallBullet;
    public Transform Player;
    public Transform PlayerRed;
    public Transform PlayerBlue;
    public float nextFire = 0.0F;
    public float fireRate = 1;
    public int attackRange = 2;
    public int Health = 75;

    //Event to manage Points the PLayer gets
    //public event Action getPoint = delegate { };
    //public event Action get10Points = delegate { };


    // Use this for initialization
    void Start()
    {
        


    }
    // Update is called once per frame
    void Update()
    {
        decideToShoot( Player);
        decideToShoot( PlayerRed);
        decideToShoot( PlayerBlue);



    }


    void decideToShoot(Transform Player)
    {
        if (PlayerIsClose( Player))
        {
            if (Time.time > nextFire)
            {
                if (shootRight(Player))
                {
                    Shoot(firePointRight);
                    nextFire = Time.time + fireRate;
                }
                else
                {
                    Shoot(firePointLeft);
                    nextFire = Time.time + fireRate;
                }
            }
        }
    }
    bool shootRight(Transform Player)
    {
        bool yes = true;
        if((Vector3.Distance(Player.position, firePointRight.position)) > Vector3.Distance(Player.position, firePointLeft.position)){
            yes = false;
        }
        else{
            yes = true;
        }
        return yes;
    }

    bool  PlayerIsClose(Transform Player)
    {
        bool yes;
        if (Vector3.Distance(firePointLeft.position, Player.position) < attackRange)
        {
            yes= true;
        }else
        {
            yes= false;
        }
        return yes;

    }
    void Shoot(Transform firePoint)
    {
        
        AimAtPlayer(firePoint);
        
        Rigidbody Bullet = Instantiate(smallBullet, firePoint.position + firePoint.forward, firePoint.rotation);
        Bullet.AddForce(firePoint.forward * 400);
        //print("fired");
    }
    //TODO implement aimatplayer
    void AimAtPlayer(Transform firePoint)
    {
        firePoint.LookAt(Player);
    }
    public void takeDamage(int damage)
    {
        this.Health -= damage;
    }

    void OnCollisionEnter(Collision collision)
    {
        //take damage when hit by bullet
        if (collision.gameObject.tag == "PlayerBullet")
        {
            takeDamage(10);
            //getPoint();
            UIPoints.UIpts += 1;
            if (this.Health <= 0)
            {
                //get10Points();
                UIPoints.UIpts += 1;
                Destroy(gameObject);
                
            }
        }
    }


}
