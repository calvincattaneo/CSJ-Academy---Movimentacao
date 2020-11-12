using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour {

    public float Speed;
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
    }
}
