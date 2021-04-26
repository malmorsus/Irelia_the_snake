using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BloodStop : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        Invoke("StopBlood", 0.2f);
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    void StopBlood()
    {
        GetComponent<Rigidbody2D>().velocity = Vector2.zero;
    }
}
