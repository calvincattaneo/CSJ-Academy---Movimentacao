using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public float JumpForce;
    private bool isGrounded;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    
    void FixedUpdate() {
        if(Input.GetKey(KeyCode.LeftArrow)) {
            rig.velocity = new Vector2(-Speed, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = true;
        } else {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.RightArrow)) {
            rig.velocity = new Vector2(Speed, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 8) {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }    
    }
}
