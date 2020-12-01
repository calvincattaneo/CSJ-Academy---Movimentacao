using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour {
    public float Speed;
    private Player player;
    private SpriteRenderer spritePlayer;
    private bool direction;

    private void Start() {
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Player>();
        spritePlayer = player.GetComponent<SpriteRenderer>();
        direction = spritePlayer.flipX;
        Destroy(gameObject, 3f);
    }

    void Update() {
        if(direction) {
            transform.Translate(Vector2.left * Time.deltaTime * Speed);
        }
        else {
            transform.Translate(Vector2.right * Time.deltaTime * Speed);
        }
        
    }
}
