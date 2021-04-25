using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    //Projectile NEEDS collider2D set to trigger

    public float speed;

    private Transform player;
    private Vector2 target;

   
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;

        target = new Vector2(player.position.x, player.position.y);
    }

    
    void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, target, speed * Time.deltaTime);

        /*if (transform.position.x == target.x && transform.position.y == target.y)
        {
            DestroyProjectile();
        }
        */
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
        }
    }

    void DestroyProjectile()
    {
        Destroy(gameObject);
    }
}
