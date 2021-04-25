using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordBroke : MonoBehaviour
{
    public GameObject Sword;

    public void BrokeSword()
    {
        FindObjectOfType<SpawnSword>().WithSword = false;
        GameObject newSword = Instantiate(Sword);
        newSword.transform.position = gameObject.transform.position;
        Destroy(gameObject);
    }
}
