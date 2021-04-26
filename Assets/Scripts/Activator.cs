using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Activator : MonoBehaviour
{
    public List<EnemyHealth> AliveEnemys = new List<EnemyHealth>();

    private int scene;

    private void Start()
    {
        scene = SceneManager.GetActiveScene().buildIndex;
    }

    void Update()
    {
        if (AliveEnemys.Count <= 0)
        {
            SceneManager.LoadScene(scene + 1);
        }

    }
}
