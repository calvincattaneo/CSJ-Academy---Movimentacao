using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
    public float JumpForce;
    private float timeAttack;
    public float startTimeAttack;
    private bool isGrounded;
    private Rigidbody2D rig;
    private Animator anim;
    private SpriteRenderer sprite;

    void Start() {
        rig = GetComponent<Rigidbody2D>();
        anim = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();
    }

    private bool isAtk;
    void FixedUpdate() {
        if(Input.GetKey(KeyCode.LeftArrow) && !isAtk) {
            rig.velocity = new Vector2(-Speed, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = true;
        } else {
            rig.velocity = new Vector2(0, rig.velocity.y);
            anim.SetBool("isWalking", false);
        }

        if (Input.GetKey(KeyCode.RightArrow) && !isAtk) {
            rig.velocity = new Vector2(Speed, rig.velocity.y);
            anim.SetBool("isWalking", true);
            sprite.flipX = false;
        }

        if (Input.GetKeyDown(KeyCode.UpArrow) && isGrounded) {
            rig.AddForce(Vector2.up * JumpForce, ForceMode2D.Impulse);
            anim.SetBool("isJumping", true);
            isGrounded = false;
        }

        if(timeAttack <= 0 ) {
            isAtk = false;
            if (Input.GetKeyDown(KeyCode.Z)) {
                //anim.SetTrigger("isAttacking");
                anim.SetBool("isAtk", true);
                timeAttack = startTimeAttack;
                isAtk = true;
            }
        } else {
            timeAttack -= Time.deltaTime;
            //anim.SetTrigger("isAttacking");
            anim.SetBool("isAtk", false);
        }

        anim.SetBool("isAtk", isAtk);
    }

    void OnCollisionEnter2D(Collision2D collision) {
        if(collision.gameObject.layer == 8) {
            isGrounded = true;
            anim.SetBool("isJumping", false);
        }    
    }
}
