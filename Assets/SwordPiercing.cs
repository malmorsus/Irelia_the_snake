using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordPiercing : MonoBehaviour
{
    public TrailRenderer TrailR;
    private bool SwordStuck = false;
    private Transform NewParent;
    private SwordMove SwordMove;
    private void Start()
    {
        SwordMove = FindObjectOfType<SwordMove>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PlayerHealth>() == false && collision.GetComponentInParent<SwordPiercing>() == false)
        {
            if (SwordStuck == false)
            {
                NewParent = collision.transform;
                Invoke("Piercing", 0.05f);
            }
        }
   
    }

    public void Piercing()
    {
        SwordMove.enabled = false;
        SwordMove.Rigidbody2D.velocity = Vector2.zero;
        SwordMove.Rigidbody2D.isKinematic = true;
        TrailR.enabled = false;
        FindObjectOfType<SpawnSword>().WithSword = false;
        SwordMove.gameObject.transform.SetParent(NewParent, true);
        //SwordMove.gameObject.transform.localScale = new Vector3(1f, 1f, 1f);
        SwordStuck = true;
    }
}
