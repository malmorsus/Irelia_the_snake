using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemy NEEDS rigidbody2D and collider2D

    public int health;
    private int currentHealth;
    public Blood Blood;

    private void Start()
    {
        currentHealth = health;
    }

    void Update()
    {
        if (currentHealth > health)
        {
            Blood.BloodBoom();
            currentHealth = health;
        }
        
        if (health <= 0)
        {
            Invoke("DestroyEnemy", 0.1f);
            for (int i = 0; i < GetComponentsInChildren<SwordPiercing>().Length; i++)
            {
                GetComponentsInChildren<SwordPiercing>()[i].SpuwnNewSword();
            }
        }
    }

    public void DestroyEnemy()
    {
        Destroy(gameObject);
    }
}
