using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwordMove : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float SpeedChase;
    public float SpeedFree;
    public Camera Camera;
    public float StopDistance;
    public bool _isChase = true;
    public bool _isFliesBack = false;

    private Vector2 moveTo;
    private Vector2 MoveVelocity;
    private Vector3 mousPosition;
    private Vector3 PlayerPosition;

    private void Start()
    {
        Camera = FindObjectOfType<Camera>();
        PlayerPosition = FindObjectOfType<PlayerMove>().transform.position;
    }

    void Update()
    {
        mousPosition = Camera.ScreenToWorldPoint(Input.mousePosition);
        Vector2 direction = new Vector2(mousPosition.x - transform.position.x, mousPosition.y - transform.position.y);

        if (_isFliesBack)
        {
            PlayerPosition = FindObjectOfType<PlayerMove>().transform.position;
            moveTo = PlayerPosition - transform.position;
            transform.up = moveTo;
            if (Mathf.Abs(moveTo.x) <= StopDistance && Mathf.Abs(moveTo.y) <= StopDistance)
            {
                FindObjectOfType<SpawnSword>().WithSword = false;
                Destroy(gameObject);
            }
        }
        else
        {
            if (_isChase)
            {
                transform.up = direction;
                moveTo = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
            }

            if (Mathf.Abs(moveTo.x) <= StopDistance && Mathf.Abs(moveTo.y) <= StopDistance)
            {
                _isChase = false;
                _isFliesBack = true;
            }

            if (Input.GetMouseButtonDown(0))
            {
                _isChase = false;
                FindObjectOfType<SwordPiercing>().SwordStartWait = false;
            }
        }
    }

    private void FixedUpdate()
    {
        if (_isChase)
        {
            MoveVelocity = moveTo.normalized * SpeedChase;
            Rigidbody2D.velocity = MoveVelocity * SpeedChase;
        }
        else
        {
            MoveVelocity = moveTo.normalized * SpeedFree;
            Rigidbody2D.velocity = MoveVelocity * SpeedFree;
        }
    }

}
