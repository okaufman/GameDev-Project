﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

   //[SerializeField]
    private InputManager inputManager;
    public event Action FireWeapon = delegate { };
   // public int Health = 100;

    private bool isDead = false;
    private float speedForce = 15f;
    private float maxSpeed = 20f;
    private float jumpForce = 600f;
    private bool grounded = true;

    private Animator animator;
    private Rigidbody rb2d;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int frame = 10;
    private float deltaTime = 0;
    private float frameSeconds = 0.1f;

    void Start () {
        inputManager = FindObjectOfType<InputManager>();
        inputManager.PAttack += OnAttack;
        animator = GetComponent<Animator>();
        animator.enabled = false;
        rb2d = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("bear");
    }

	void Update () {
        if (!isDead) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
                rb2d.AddForce(new Vector2(0f, jumpForce));
                grounded = false;
            }
            //save current rotation
            Vector3 currRot = transform.eulerAngles;
            if (Input.GetKeyDown(KeyCode.LeftArrow) & transform.rotation.y==0.0F) {
                //change rotation
                currRot.y += 180;
                //assign new Rotation to object
                transform.eulerAngles = currRot;
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) & transform.rotation.y == 1.0F) {
                //change rotation
                currRot.y -= 180;
                //assign new Rotation to object
                transform.eulerAngles = currRot;
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                animate();
                if (rb2d.velocity.x > -maxSpeed)
                    rb2d.AddForce(transform.right * speedForce);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                animate();
                if (rb2d.velocity.x < maxSpeed)
                    print(transform.forward);
                    rb2d.AddForce(transform.right * speedForce);
            }
        }

       
        


    }

    private void animate() {
        deltaTime += Time.deltaTime;
        while (deltaTime >= frameSeconds) {
            deltaTime -= frameSeconds;
            if (frame < 21) {
                frame++;
            } else {
                frame = 10;
            }
        }
        spriteRenderer.sprite = sprites[frame];
    }

    private void OnCollisionEnter(Collision collision)
    {
        //be able to jump again, when you have hit the ground
        if (collision.gameObject.tag == "ground") {
        grounded = true;
    }
        //take damage when hit by bullet
        if (collision.gameObject.tag == "EnemyBullet")
        {
            takeDamage(10);
            if (UIHealth.health <= 0)
            {
                SceneManager.LoadScene(0);
            }
        }
    }

    public void SetSpeedForce(float force) {
        speedForce = force;
    }

    public void SetMaxSpeed(float speed) {
        maxSpeed = speed;
    }

    public void takeDamage(int damage)
    {
        UIHealth.health -= damage;
    }

     void OnAttack()
    {
        FireWeapon();
    }
}
