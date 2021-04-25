using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    //Player NEEDS rigidbody2D and collider2D

    public int health;
    public bool isInvincible = false;

    private SpriteRenderer rend;
    Color c;
    
    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        c = rend.color;
    }

    void Update()
    {
        if (isInvincible)
        {
            StartCoroutine(GetIFrames());
            
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }

    public void TakeDamage()
    {
        isInvincible = true;
        Debug.Log("Im invincible");
        health--;
    }

    IEnumerator GetIFrames()
    {
        c.a = 0.5f;
        rend.color = c;
        yield return new WaitForSeconds(2f);
        c.a = 1f;
        rend.color = c;
        yield return null;
        isInvincible = false;
        Debug.Log("Im frail");
        
    }
}
