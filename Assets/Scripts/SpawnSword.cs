using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSword : MonoBehaviour
{
    public GameObject SwordPrefab;
    public Transform Spawn;
    public bool WithSword = false;
    private float SwordStartWaitTime = 0.5f;


    void Update()
    {
        if (WithSword == false)
        {
            if (Input.GetMouseButtonDown(0))
            {
                WithSword = true;
                Invoke("StartWait", SwordStartWaitTime);
                Throw();
            }
        }
    }
  
    public void Throw()
    {
        GameObject newSword = Instantiate(SwordPrefab, Spawn.position, Spawn.rotation);
    }

    public void StartWait()
    {
        FindObjectOfType<SwordPiercing>().SwordStartWait = false;
        //FindObjectOfType<SwordPiercing>().SwordCollider.enabled = true;
    }
}
