using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Player NEEDS rigidbody2D and collider2D

    public int health;

    void Update()
    {
        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
