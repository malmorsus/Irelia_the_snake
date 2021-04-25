using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform player;
    Transform sword;

    public bool _isFollowPlayer = true;

    void Start()
    {
        cameraFollow.Setup(() => player.position);
    }

    void Update()
    {
        if (FindObjectOfType<SpawnSword>().WithSword == true && FindObjectOfType<SwordMove>()._isChase == true)
        {
            FollowSword();
            _isFollowPlayer = false;
        }
        if (Input.GetKeyUp(KeyCode.Mouse0))
        {
            Invoke("FollowPlayer", 0.5f);
        }

        if (_isFollowPlayer || FindObjectOfType<SpawnSword>().WithSword == false)
        {
            FollowPlayer();
        }
    }

    public void FollowSword()
    {
        if (FindObjectOfType<SwordMove>())
        {
            sword = FindObjectOfType<SwordMove>().transform;
            cameraFollow.SetGetCameraFollowPositionFunc(() => sword.position);
        }
    }

    public void FollowPlayer()
    {
        cameraFollow.SetGetCameraFollowPositionFunc(() => player.position);
        _isFollowPlayer = true;
    }

}
