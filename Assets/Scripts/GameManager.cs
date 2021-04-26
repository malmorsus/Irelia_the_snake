using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public CameraFollow cameraFollow;
    public Transform player;
    Transform sword;

    public bool _isFollowPlayer = true;

    public GameObject textUI;
    
    public bool gameEnded = false;

    private int scene;

    void Start()
    {
        cameraFollow.Setup(() => player.position);
        scene = SceneManager.GetActiveScene().buildIndex;
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

        if (FindObjectOfType<PlayerHealth>().health <= 0)
        {
            textUI.SetActive(true);
            gameEnded = true;
        }
        else
        {
            textUI.SetActive(false);
            gameEnded = false;
        }

        if (Input.GetKeyDown(KeyCode.R) && gameEnded)
        {
            
            Debug.Log("RESTARTED");
            SceneManager.LoadScene(scene);
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

    public void LoadScene()
    {
        SceneManager.LoadScene(scene);
    }
}
