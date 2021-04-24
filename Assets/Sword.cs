using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public float Speed;
    public float RotationSpeed;
    public Camera Camera;
    public Transform Pointer;

    public Vector3 lookUp;
    void Start()
    {
        Pointer = FindObjectOfType<Pointer>().transform;
    }


    void Update()
    {
        transform.position += Time.deltaTime * transform.forward * Speed;
        transform.position = new Vector3(transform.position.x, 1f, transform.position.z);
        Vector3 toPlayer = Pointer.position - transform.position;
        Quaternion targetRotation = Quaternion.LookRotation(toPlayer, lookUp);

        transform.rotation = Quaternion.Lerp(transform.rotation, targetRotation, Time.deltaTime * RotationSpeed);

    }

}
