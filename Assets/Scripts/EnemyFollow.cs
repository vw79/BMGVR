using UnityEngine;
using UnityEngine.AI;

public class EnemyFollow : MonoBehaviour
{
    [SerializeField] private Transform[] waypoints = new Transform[2];
    [SerializeField] private float patrolSpeed = 3.0f;
    private Transform currentTarget;

    private void Start()
    {
        currentTarget = waypoints[0];
    }

    private void Update()
    {
        Patrol();
    }

    private void Patrol()
    {
        transform.LookAt(currentTarget);
        transform.position = Vector3.MoveTowards(transform.position, currentTarget.position, patrolSpeed * Time.deltaTime);
        if (Vector3.Distance(transform.position, currentTarget.position) < 0.3f)
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

    private void OnTriggerEnter(Collider collision)
    {
        if (collision.gameObject.CompareTag("Bullet"))
        {
            Destroy(gameObject);
        }
    }
}
