using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PickUpSword : MonoBehaviour
{
    public GameObject Sword;
    private SwordsTail SwordsTail;
    void Start()
    {
        SwordsTail = FindObjectOfType<SwordsTail>();
    }

    /*
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Q))
        {
            GameObject sword = Instantiate(Sword, SwordsTail.transform);
            SwordsTail.CollectSword(sword);
        }
    }
    */

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<Rigidbody2D>())
        {
            if (collision.GetComponentInParent<SwordsTail>())
            {
                GameObject sword = Instantiate(Sword, SwordsTail.transform);
                SwordsTail.CollectSword(sword);
                Destroy(gameObject);
            }
        }
    }
}
