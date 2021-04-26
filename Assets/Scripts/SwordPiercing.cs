using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPiercing : MonoBehaviour
{
    public int SwordDamage = 1;
    public TrailRenderer TrailR;
    public Collider2D SwordCollider;

    public bool SwordStartWait = true;

    private bool SwordStuck = false;
    private Transform NewParent;
    private SwordMove SwordMove;
    public bool FirstDealtDamage = true;

    public GameObject Sword;

    private void Start()
    {
        SwordMove = FindObjectOfType<SwordMove>();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<RotateShield>())
        {

            SwordMove.enabled = false;
            FindObjectOfType<SpawnSword>().WithSword = false;
            Invoke("SpuwnNewSword", 0f);
            FindObjectOfType<AudioManager>().Play("Shield");
            return;
        }

        if (SwordStartWait == false)
        {

            if (collision.GetComponentInParent<PlayerHealth>() == false && collision.GetComponentInParent<SwordPiercing>() == false)
            {
                if (SwordStuck == false)
                {
                    NewParent = collision.transform;
                    Invoke("Piercing", 0.05f);
                    
                }
            }

            if (collision.GetComponentInParent<EnemyHealth>())
            {
                if (FirstDealtDamage)
                {
                    FirstDealtDamage = false;
                    collision.GetComponentInParent<EnemyHealth>().health -= SwordDamage;
                    FindObjectOfType<AudioManager>().Play("Attack");
                    return;
                }
            }
        }
   
    }

    public void Piercing()
    {
        SwordMove.enabled = false;
        SwordMove.Rigidbody2D.velocity = Vector2.zero;
        SwordMove.Rigidbody2D.isKinematic = true;
        TrailR.enabled = false;
        SwordCollider.enabled = false;
        FindObjectOfType<SpawnSword>().WithSword = false;
        SwordMove.gameObject.transform.SetParent(NewParent, true);
        //SwordMove.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        SwordStuck = true;
        Invoke("SpuwnNewSword", 3f);
    }

    public void SpuwnNewSword()
    {
        GameObject newSword =  Instantiate(Sword);
        newSword.transform.position = gameObject.transform.position;
        newSword.transform.parent = null;
        Destroy(gameObject);
    }
}
