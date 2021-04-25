using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSword : MonoBehaviour
{
    public GameObject SwordPrefab;
    public Transform Spawn;
    public bool WithSword = false;
    private float SwordStartWaitTime = 0.5f;
    public float SpawnCD = 0.5f;
    private float waitTime = 0f;
     
    void Update()
    {
        if (waitTime <= 0)
        {
            if (WithSword == false)
            {
                if (Input.GetMouseButtonDown(0))
                {
                    WithSword = true;
                    Invoke("StartWait", SwordStartWaitTime);
                    Throw();
                    waitTime = SpawnCD;
                }
            }
        }
        else
        {
            waitTime -= Time.deltaTime;
        }
    }
  
    public void Throw()
    {
        GameObject newSword = Instantiate(SwordPrefab, Spawn.position, Spawn.rotation);
    }

    public void StartWait()
    {
        if(FindObjectOfType<SwordPiercing>())
            FindObjectOfType<SwordPiercing>().SwordStartWait = false;
        //FindObjectOfType<SwordPiercing>().SwordCollider.enabled = true;
    }
}
