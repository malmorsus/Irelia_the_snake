using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerHealth : MonoBehaviour
{
    //Player NEEDS rigidbody2D and collider2D

    public int health;
    public bool isInvincible = false;

    public UnityEvent EventOnTakeDamage;

    private SpriteRenderer rend;
    Color c;
    
    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        c = rend.color;
    }

    /*void Update()
    {
        if (isInvincible)
        {
            StartCoroutine(GetIFrames());
            
        }

        if (health <= 0)
        {
            Destroy(gameObject);
        }
    }*/

    public void TakeDamage()
    {
        if (isInvincible == false)
        {
            isInvincible = true;
            health--;
            if (health <= 0)
            {
                Destroy(gameObject);
            }
            Debug.Log("Im invincible");
            Invoke("StopInvincible", 2f);
            EventOnTakeDamage.Invoke();
        }
    }

    void StopInvincible()
    {
        isInvincible = false;
    }

    /*IEnumerator GetIFrames()
    {
        c.a = 0.5f;
        rend.color = c;
        yield return new WaitForSeconds(2f);
        c.a = 1f;
        rend.color = c;
        yield return null;
        //isInvincible = false;
        //Debug.Log("Im frail");
        
    }*/
}
