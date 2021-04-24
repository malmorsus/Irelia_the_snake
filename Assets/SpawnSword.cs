using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnSword : MonoBehaviour
{
    public GameObject SwordPrefab;
    public Transform Spawn;
    public bool WithSword = false;

    void Update()
    {
        if (WithSword == false)
        {
            if (Input.GetMouseButton(0))
            {
                WithSword = true;
                Throw();
            }
        }
    }
  
    public void Throw()
    {
        GameObject newSword = Instantiate(SwordPrefab, Spawn.position, Spawn.rotation);
    }
}
