using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Pointer : MonoBehaviour
{
    public Transform Aim;
    public Camera Camera;
    public Vector3 toAim;

    public Vector3 _Plane;
    void LateUpdate()
    {
        Ray ray = Camera.ScreenPointToRay(Input.mousePosition);
        Debug.DrawRay(ray.origin,ray.direction*50,Color.yellow);


        Plane plane = new Plane(_Plane, Vector3.zero);

        float distance;
        plane.Raycast(ray, out distance);
        Vector3 point = ray.GetPoint(distance);

        transform.position = point;

        toAim = transform.position - transform.position;
        transform.rotation = Quaternion.LookRotation(toAim);
    }
}
