using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.Events;
using EZCameraShake;

public class PlayerHealth : MonoBehaviour
{
    //Player NEEDS rigidbody2D and collider2D

    public int health;
    public bool isInvincible = false;

    public UnityEvent EventOnTakeDamage;

    private SpriteRenderer rend;
    Color c;

    [Header("UI")]
    public int numOfHearts;
    public Image[] hearts;
    public Sprite fullHeart;
    public Sprite emptyHeart;
    
    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
        c = rend.color;
    }

    void Update()
    {
        if (health > numOfHearts)
        {
            health = numOfHearts;
        }

        for (int i=0; i < hearts.Length; i++)
        {
            if (i < health)
            {
                hearts[i].sprite = fullHeart;
            }
            else
            {
                hearts[i].sprite = emptyHeart;
            }

            if (i < numOfHearts)
            {
                hearts[i].enabled = true;
            }
            else
            {
                hearts[i].enabled = false;
            }
        }
    }

    public void TakeDamage()
    {
        if (isInvincible == false)
        {
            CameraShaker.Instance.ShakeOnce(4f, 4f, .1f, 1f);
            isInvincible = true;
            health--;
            FindObjectOfType<AudioManager>().Play("Damage");
            if (health <= 0)
            {
                hearts[0].sprite = emptyHeart;
                
                Destroy(gameObject, .1f);
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
