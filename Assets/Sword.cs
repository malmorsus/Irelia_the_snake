using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sword : MonoBehaviour
{
    public Rigidbody2D Rigidbody2D;
    public float Speed;
    public float RotationSpeed;
    public Camera Camera;

    private Vector2 MoveVelocity;


    public Vector3 mousPosition;
    /*
    public Vector3 to—ursor;
    public Quaternion targetRotation;
    */

    void Update()
    {
        Vector2 moveTo = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        MoveVelocity = moveTo.normalized * Speed;


        mousPosition = Camera.ScreenToWorldPoint(Input.mousePosition);

        Vector2 direction = new Vector2(mousPosition.x - transform.position.x, mousPosition.y - transform.position.y);

        transform.up = direction;

        //transform.localPosition += Time.deltaTime * Vector3.up * Speed;
        //transform.localPosition = new Vector3(transform.position.x, transform.position.y, 0f);

        //Vector3 to—ursor = Camera.ScreenToWorldPoint(Input.mousePosition) - transform.position;
        //Quaternion targetRotation = Quaternion.LookRotation(to—ursor, lookUp);

        //transform.rotation = Quaternion.Lerp(transform.rotation, Quaternion.Euler(moveTo.normalized), Time.deltaTime * RotationSpeed);
        //transform.rotation = Quaternion.Euler(0f, 0f, transform.rotation.z);
    }

    private void FixedUpdate()
    {
        Rigidbody2D.velocity = MoveVelocity * Speed;
        //Rigidbody2D.MovePosition(Rigidbody2D.position + MoveVelocity * Time.fixedDeltaTime);
    }

}
