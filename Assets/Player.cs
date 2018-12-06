using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    private bool isDead = false;
    private float speedForce = 20f;
    private float maxSpeed = 30f;
    private float jumpForce = 1000f;
    private bool grounded = true;

    private Animator animator;
    private Rigidbody2D rb2d;
    private SpriteRenderer spriteRenderer;
    private Sprite[] sprites;
    private int frame = 10;
    private float deltaTime = 0;
    private float frameSeconds = 0.1f;

    void Start () {
        animator = GetComponent<Animator>();
        animator.enabled = false;
        rb2d = GetComponent<Rigidbody2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        sprites = Resources.LoadAll<Sprite>("bear");
    }

	void Update () {
        if (!isDead) {
            if (Input.GetKeyDown(KeyCode.Space) && grounded) {
                rb2d.AddForce(new Vector2(0f, jumpForce));
                grounded = false;
            }
            if (Input.GetKeyDown(KeyCode.LeftArrow) & transform.localScale.x > 0) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKeyDown(KeyCode.RightArrow) & transform.localScale.x < 0) {
                transform.localScale = new Vector3(-transform.localScale.x, transform.localScale.y, transform.localScale.z);
            }
            if (Input.GetKey(KeyCode.LeftArrow)) {
                animate();
                if (rb2d.velocity.x > -maxSpeed)
                    rb2d.AddForce(-transform.right * speedForce);
            }
            if (Input.GetKey(KeyCode.RightArrow)) {
                animate();
                if (rb2d.velocity.x < maxSpeed)
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

    private void OnCollisionEnter2D(Collision2D collision) {
        if (collision.gameObject.tag == "ground") {
            grounded = true;
        }
    }

    public void SetSpeedForce(float force) {
        speedForce = force;
    }

    public void SetMaxSpeed(float speed) {
        maxSpeed = speed;
    }
}
