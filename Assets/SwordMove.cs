using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public Camera Camera;
    public float StopDistance;

    private bool _isChase = true;
    private Vector2 moveTo;
    private Vector2 MoveVelocity;
    private Vector3 mousPosition;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
    }

    void Update()
    {
        mousPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousPosition.x - transform.position.x, mousPosition.y - transform.position.y);

        if (_isChase)
        {
            transform.up = direction;
            moveTo = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;           
        }

        MoveVelocity = moveTo.normalized * Speed; 
        
        if (Mathf.Abs(moveTo.x) <= StopDistance && Mathf.Abs(moveTo.y) <= StopDistance)
        {
            _isChase = false;
        }

    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = MoveVelocity * Speed;
    }

}
