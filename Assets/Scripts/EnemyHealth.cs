using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemy NEEDS rigidbody2D and collider2D

    public int health;

    void Update()
    {
        if (health <= 0)
        {
            Invoke("DestroyEnemy", 0.1f);
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
