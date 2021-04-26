using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
using UnityEngine;

public class WeakEnemyAI : MonoBehaviour
{
    public Animator Animator;

    [Header("Movement Parameters")]
    public float patrollingMoveSpeed;
    private float waitTime;
    public float startWaitTimeBtwPatrolling;
    public float moveSpeedTowardsPlayer;
    public float agroRange;
    public float dashRange;
    public float dashSpeedTowardsPlayer;
    public float dashTimerCD = 1f;
    public Transform player;
    private bool isDashing = false;

    [Header("Move Spots")]
    public Transform[] moveSpots;
    private int randomSpot;

    private Vector2 target;
    private float _timer = 0.5f;
    private bool _isDashSTOP = false;

    // Start is called before the first frame update
    void Start()
    {
        for (int i = 0; i < moveSpots.Length; i++)
        {
            moveSpots[i].parent = null;
        }
        player = FindObjectOfType<PlayerMove>().transform;
        waitTime = startWaitTimeBtwPatrolling;
        randomSpot = Random.Range(0, moveSpots.Length);
    }

    // Update is called once per frame
    void Update()
    {
        float distToPlayer = Vector2.Distance(transform.position, player.position);
           
        if(isDashing)
        {
            DashOnPlayer();
        }
        else if (distToPlayer < agroRange && distToPlayer > dashRange)
        {
            ChasePlayer();               
        }
        else if (distToPlayer <= dashRange)
        {
            _timer += Time.deltaTime;
            if (_timer > dashTimerCD)
            {
                if (!isDashing)
                {
                    target = new Vector2(player.position.x, player.position.y) - new Vector2(transform.position.x, transform.position.y);
                    isDashing = true;
                }
                DashOnPlayer();
            }
        }
        else
        {
            Patroll();
        }
             
    }

    void ChasePlayer()
    {
        //if (Vector2.Distance(transform.position, player.position) > (dashRange - 4f))
        //{
            Debug.Log("ChasePlayer");
            transform.position = Vector2.MoveTowards(transform.position, player.position, moveSpeedTowardsPlayer * Time.deltaTime);
        //}
    }

    void DashOnPlayer()
    {
        //if (Vector2.Distance(transform.position, target) > 1f)
        //{
        Debug.Log("DashOnPlayer");
        //transform.position = Vector2.MoveTowards(transform.position, target, dashSpeedTowardsPlayer * Time.deltaTime);

        GetComponent<Rigidbody2D>().velocity = target.normalized * dashSpeedTowardsPlayer;
        //}       
        //else 
        if (_isDashSTOP == false)
        {
            Invoke("STOPDash", 1f);
            _isDashSTOP = true;
        }
    }

    void STOPDash()
    {
        if (isDashing)
        {
            Debug.Log("STOP_Dash");
            GetComponent<Rigidbody2D>().velocity = Vector3.zero;
            isDashing = false;
            _timer = 0f;
            _isDashSTOP = false;
        }
    }

    void Patroll()
    {
        Debug.Log("Patroll");
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

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (isDashing)
        {
            if (other.GetComponentInParent<Rigidbody2D>())
            {
                if (other.GetComponentInParent<PlayerHealth>())
                {
                    if (other.GetComponentInParent<PlayerHealth>().isInvincible == false)
                    {
                        other.GetComponentInParent<PlayerHealth>().TakeDamage();
                    }

                }
            }
        }

    }


#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.grey;
        Handles.DrawWireDisc(transform.position, Vector3.forward, agroRange);
        Handles.DrawWireDisc(transform.position, Vector3.forward, dashRange);
    }
#endif
}
