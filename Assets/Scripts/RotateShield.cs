using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RotateShield : MonoBehaviour
{
    public Transform Object;
    public Transform target;
    public float offset;

    void Start()
    {
        target = FindObjectOfType<PlayerHealth>().transform;
    }


    void Update()
    {
        Vector3 toTarget = target.position - Object.position;
        toTarget.Normalize();
        float rotZ = Mathf.Atan2(toTarget.y, toTarget.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, rotZ - offset);
    }
}
