using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttack : MonoBehaviour {
    

    [SerializeField]
    private Rigidbody bulletPrefab;
    public Transform LazerFirePoint;
    private Vector3 startPosition;

    public float nextFire = 0.0F;
    public float fireRate = 0.3F;

	// Use this for initialization
	void Start () {
        if (GetComponentInParent<Player>())
        {
            GetComponentInParent<Player>().FireWeapon += shoot;
        }
        
	}
	
	// Update is called once per frame
	void Update () {
        

    }

    public void shoot()
    {

        if (Time.time > nextFire)
        {
            Rigidbody Bullet = Instantiate(bulletPrefab, LazerFirePoint.position, LazerFirePoint.rotation);
            Bullet.AddForce(LazerFirePoint.forward * 200);
            nextFire = Time.time + fireRate;
        }
    }
}
