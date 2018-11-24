using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TEnemyGun : MonoBehaviour {
    public Transform firePoint;
    public Rigidbody smallBullet;
    public Transform Player;
    public int fireRate = 200;


    // Use this for initialization
    void Start () {
        int Health = 100;
        int Resilience = 0;
	}
	// Update is called once per frame
	void Update () {
        AimAtPlayer();
        StartCoroutine(Shoot());
    }
    IEnumerator Shoot()
    {
        print("start");
        Rigidbody Bullet = Instantiate(smallBullet, firePoint.position + firePoint.forward, firePoint.rotation);
        Bullet.AddForce(firePoint.forward * 200);
        //wait a couple seconds before firing again
        yield return new WaitForSeconds(fireRate);
        print("fired");
    }
    //TODO implement aimatplayer
    void AimAtPlayer()
    {
        firePoint.LookAt(Player);
    }



}
