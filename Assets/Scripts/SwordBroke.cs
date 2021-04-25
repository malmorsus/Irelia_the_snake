using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBroke : MonoBehaviour
{

    public void BrokeSword()
    {
        FindObjectOfType<SpawnSword>().WithSword = false;
        Destroy(gameObject);
    }
}
