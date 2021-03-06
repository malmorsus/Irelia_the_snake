using System.Collections;
using System.Collections.Generic;
#if UNITY_EDITOR
using UnityEditor;
#endif
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
    public float startTimeBtwShotsShort;
    private bool ShortAlready;
    private Vector2 randomVector;

    public float agroTimeCD = 1.5f;
    private float _timer = 0.5f;

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
        _timer += Time.deltaTime;
        if (_timer > agroTimeCD)
        {
            if (distToPlayer < agroRange)
            {
                AttackPlayer();
            }
            else
            {
                Patroll();
            }
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
            if (timeBtwShots <= startTimeBtwShotsShort)
            {
                if (ShortAlready == false)
                {

                    Invoke("Shoot", 0.1f);
                    Invoke("Shoot", 0.3f);
                    Invoke("Shoot", 0.5f);

                    ShortAlready = true;
                }
                if (timeBtwShots <= 0)
                {
                    timeBtwShots = startTimeBtwShots;
                    _timer = 0f;
                    randomSpot = Random.Range(0, moveSpots.Length);
                    ShortAlready = false;
                }
                else
                {
                    timeBtwShots -= Time.deltaTime;
                }
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
#if UNITY_EDITOR
    private void OnDrawGizmosSelected()
    {
        Handles.color = Color.grey;
        Handles.DrawWireDisc(transform.position, Vector3.forward, agroRange);
        Handles.DrawWireDisc(transform.position, Vector3.forward, retreatDistance);
    }
#endif
    void Shoot()
    {
        randomVector = new Vector2(Random.Range(-1.5f, 1.5f), Random.Range(-1.5f, 1.5f));
        var shotPoint = new Vector2(transform.position.x + randomVector.x, transform.position.y + randomVector.y);
        Instantiate(projectile, shotPoint, Quaternion.identity);
    }

}
