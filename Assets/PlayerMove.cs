using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody Rigidbody;
    public float MoveSpeed;
    public float Friction;


    private void FixedUpdate()
    {
        Rigidbody.AddForce(Input.GetAxis("Horizontal") * MoveSpeed, 0, Input.GetAxis("Vertical") * MoveSpeed, ForceMode.VelocityChange);
        Rigidbody.AddForce(-Rigidbody.velocity.x * Friction, 0, -Rigidbody.velocity.z * Friction, ForceMode.VelocityChange);
    }
}
