using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHealth : MonoBehaviour
{
    //Enemy NEEDS rigidbody2D and collider2D

    public int health;
    private int currentHealth;
    public Blood Blood;
    private Activator _activator;

    private void Start()
    {
        _activator = FindObjectOfType<Activator>();
        _activator.AliveEnemys.Add(this);
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
        _activator.AliveEnemys.Remove(this);
        Destroy(gameObject);
    }
}
