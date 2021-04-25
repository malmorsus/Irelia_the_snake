using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;

public class WeakEnemyAI : MonoBehaviour
{
    [Header("Movement Parameters")]
    public float patrollingMoveSpeed;
    private float waitTime;
    public float startWaitTimeBtwPatrolling;
    public float moveSpeedTowardsPlayer;
    public float agroRange;
    public float dashRange;
    public float dashSpeedTowardsPlayer;
    public Transform player;
    private bool isDashing = false;

    [Header("Move Spots")]
    public Transform[] moveSpots;
    private int randomSpot;

    private Vector2 target;


    // Start is called before the first frame update
    void Start()
    {
        player = FindObjectOfType<PlayerMove>().transform;
        waitTime = startWaitTimeBtwPatrolling;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);

        
            
        if (distToPlayer < agroRange && distToPlayer > dashRange)
        {
            ChasePlayer();               
        }
        else if (distToPlayer <= dashRange)
        {
            if (!isDashing)
            {
                target = new Vector2(player.position.x, player.position.y);
            }
            DashOnPlayer();
        }
        else
        {
            Patroll();
        }
             
    }

    void ChasePlayer()
    {
        if (Vector2.Distance(transform.position, player.position) > 0.2f)
        {
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeedTowardsPlayer * Time.deltaTime);
        }
    }

    void DashOnPlayer()
    {
        isDashing = true;
        Debug.Log("Target locked");
        if (Vector2.Distance(transform.position, target) > 0f)
        {
            transform.position = Vector2.MoveTowards(transform.position, target, dashSpeedTowardsPlayer * Time.deltaTime);
        }       
        else if (Vector2.Distance(transform.position, target) == 0f)
        {
            isDashing = false;
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
        Handles.DrawWireDisc(transform.position, Vector3.forward, dashRange);
    }

}
