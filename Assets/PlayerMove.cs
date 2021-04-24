using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float MoveSpeed;
    public float Friction;

    private Vector2 MoveVelocity;


    private void Update()
    {
        Vector2 moveInput = new Vector2(Input.GetAxisRaw("Horizontal"), Input.GetAxisRaw("Vertical"));
        MoveVelocity = moveInput.normalized * MoveSpeed;
    }

    private void FixedUpdate()
    {
        Rigidbody2D.MovePosition(Rigidbody2D.position + MoveVelocity * Time.fixedDeltaTime);
    }
}
