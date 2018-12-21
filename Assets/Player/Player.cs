using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour {

   //[SerializeField]
    private InputManager inputManager;
    public event Action FireWeapon = delegate { };
    public static int health = 100;

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
        //reset all scores to zero
        UIHealth.health = 100;
        UIPoints.UIpts = 0;
        UIKeys.KeysFound = 0;
        UITimer.totalTime = 300;

        inputManager = FindObjectOfType<InputManager>();
        inputManager.PAttack += OnAttack;
        animator = GetComponent<Animator>();      
        rb2d = GetComponent<Rigidbody>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("bear");

    }

	void Update () {
        if (!isDead) {
            if (Input.GetKeyDown(KeyCode.UpArrow) && grounded) {
                rb2d.AddForce(new Vector2(0f, jumpForce));
                animator.SetBool("isJumping", true);
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
            if (Input.GetKey(KeyCode.LeftArrow) || Input.GetKey(KeyCode.RightArrow)) {
                animator.SetFloat("speed", speedForce);
                float x = Input.GetAxis("Horizontal");
                rb2d.velocity = new Vector2(x * speedForce, rb2d.velocity.y);
            }
            if (Input.GetKeyUp(KeyCode.LeftArrow) || Input.GetKeyUp(KeyCode.RightArrow)) {
                animator.SetFloat("speed", 0);
            }
        }
        UIHealth.health = health;
        if(isDead) {
            gameObject.SetActive(false);
        }
    }

    private void OnCollisionEnter(Collision collision)
    {
        //be able to jump again, when you have hit the ground
        if (collision.gameObject.tag == "ground") {
            grounded = true;
            animator.SetBool("isJumping", false);
        }
        //take damage when hit by bullet
        if (collision.gameObject.tag == "EnemyBullet")
        {
            takeDamage(10);
            if (health <= 0 && !isDead)
            {
                isDead = true;
                UIHealth.IncrementDeadCount();
            }
        }
    }

    public void takeDamage(int damage)
    {
        health -= damage;
    }

     public void OnAttack()
    {
        FireWeapon();
    }
}
