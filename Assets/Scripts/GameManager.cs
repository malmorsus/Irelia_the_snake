using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform player;
    Transform sword;


    void Start()
    {
        cameraFollow.Setup(() => player.position);
    }

    void Update()
    {
        if (Input.GetKey(KeyCode.Mouse0))
        {
            sword = FindObjectOfType<SwordMove>().transform;
            cameraFollow.SetGetCameraFollowPositionFunc(() => sword.position);
        }
        else
        {
            cameraFollow.SetGetCameraFollowPositionFunc(() => player.position);
        }
    }


}
