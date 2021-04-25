using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Projectile NEEDS collider2D set to trigger

    public float speed;

    private Transform player;
    private Vector2 target;
    private Rigidbody2D rb2d;


    private Vector2 moveBullet;
   
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        rb2d = GetComponent<Rigidbody2D>();
        target = new Vector2(player.position.x - transform.position.x, player.position.y- transform.position.y);
    }

    
    void Update()
    {
         moveBullet = target.normalized * speed;

        //rb2d.AddForce(transform.position * target); Это можно использовать для босса
    }

    private void FixedUpdate()
    {
        rb2d.MovePosition(rb2d.position + moveBullet * Time.fixedDeltaTime);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.GetComponentInParent<Rigidbody2D>())
        {
            if (other.GetComponentInParent<PlayerHealth>())
            {
                other.GetComponentInParent<PlayerHealth>().health--;
                DestroyProjectile();
            }
            if (other.GetComponentInParent<SwordBroke>())
            {
                other.GetComponentInParent<SwordBroke>().BrokeSword();
                DestroyProjectile();
            }

        }
        if (other.CompareTag("Walls"))
        {
            DestroyProjectile();
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
