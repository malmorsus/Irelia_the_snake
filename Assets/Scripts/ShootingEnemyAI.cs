using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class ShootingEnemyAI : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float patrollingMoveSpeed;
    private float waitTime;
    public float startWaitTimeBtwPatrolling;
    public float moveSpeedTowardsPlayer;
    public float agroRange;
    public float retreatDistance;
    public Transform player;

    [Header("Move Spots")]
    public Transform[] moveSpots;
    private int randomSpot;

    [Header("Shooting Stuff")]
    public GameObject projectile;
    private float timeBtwShots;
    public float startTimeBtwShots;
    private Vector2 randomVector;




    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < moveSpots.Length; i++)
        {
            moveSpots[i].parent = null;
        }
        player = FindObjectOfType<PlayerMove>().transform;
        timeBtwShots = startTimeBtwShots;
        waitTime = startWaitTimeBtwPatrolling;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        if (distToPlayer < agroRange)
        {
            AttackPlayer();
        }
        else
        {
            Patroll();
        }



    }

    void AttackPlayer()
    {
        if (Vector2.Distance(transform.position, player.position) < retreatDistance)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, -moveSpeedTowardsPlayer * Time.deltaTime);
        }
        else
        {
            if (timeBtwShots <= 0)
            {
                Invoke("Shoot", 0.1f);
                Invoke("Shoot", 0.1f);
                Invoke("Shoot", 0.1f);
                Invoke("Shoot", 0.1f);
                Invoke("Shoot", 0.1f);
                timeBtwShots = startTimeBtwShots;
            }
            else
            {
                timeBtwShots -= Time.deltaTime;
            }
        }
    }


    void Patroll()
    {
        transform.position = Vector2.MoveTowards(transform.position, moveSpots[randomSpot].position, patrollingMoveSpeed * Time.deltaTime);
        if (Vector2.Distance(transform.position, moveSpots[randomSpot].position) < 0.2f)
        {
            if (waitTime <= 0)
            {
                randomSpot = Random.Range(0, moveSpots.Length);
                waitTime = startWaitTimeBtwPatrolling;
            }
            else
            {
                waitTime -= Time.deltaTime;
            }
        }
    }

    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.grey;
        Handles.DrawWireDisc(transform.position, Vector3.forward, agroRange);
        Handles.DrawWireDisc(transform.position, Vector3.forward, retreatDistance);
    }

    void Shoot()
    {
        randomVector = new Vector2(Random.Range(-1f, 1f), Random.Range(-1f, 1f));
        var shotPoint = new Vector2(transform.position.x + randomVector.x, transform.position.y + randomVector.y);
        Instantiate(projectile, shotPoint, Quaternion.identity);
    }

}
