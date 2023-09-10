using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints = new Transform[2];
    [SerializeField] private float patrolSpeed = 3.0f;
    [SerializeField] private float chaseSpeed = 5.0f;
    [SerializeField] private float chaseRange = 10.0f;

    private Transform player;
    private Transform currentTarget;
    private NavMeshAgent navMesh;
    private bool isChasing = false;
    private bool isDead = false;

    private void Start()
    {
        navMesh = GetComponent<NavMeshAgent>();
        currentTarget = waypoints[0];
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if (isDead)
            return;

        float distanceToPlayer = Vector3.Distance(transform.position, player.position);

        if (distanceToPlayer <= chaseRange)
        {
            isChasing = true;
            ChasePlayer();
        }
        else if (isChasing && distanceToPlayer > chaseRange)
        {
            isChasing = false;
            currentTarget = waypoints[0];
            Patrol();
        }
        else if (!isChasing)
        {
            Patrol();
        }
    }

    private void Patrol()
    {
        navMesh.speed = patrolSpeed;
        navMesh.SetDestination(currentTarget.position);

        if (Vector3.Distance(transform.position, currentTarget.position) < 1f)
        {
            if (currentTarget == waypoints[0])
            {
                currentTarget = waypoints[1];
            }
            else
            {
                currentTarget = waypoints[0];
            }
        }
    }

    private void ChasePlayer()
    {
        navMesh.speed = chaseSpeed;
        navMesh.SetDestination(player.position);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            isDead = true;
            Destroy(gameObject);
        }
    }
}
