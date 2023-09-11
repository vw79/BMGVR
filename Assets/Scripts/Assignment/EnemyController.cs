using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyController : MonoBehaviour
{
    private Transform player;
    [SerializeField] private float speed = 0.5f;
    
    private void Start()
    {
        player = GameObject.FindGameObjectWithTag("Player").transform;
    }

    private void Update()
    {
        if(player == null)
        {
            return;
        }

        transform.LookAt(player);
        ChasePlayer();
    }

    private void ChasePlayer()
    {
        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.position.x, player.position.y + 1.2f, player.position.z), speed * Time.deltaTime);
    }

    private void OnCollisionEnter(Collision collision)
    {
        if(collision.gameObject.tag == "Player")
        {
            // Actions to let player lose or hurt player, depends on the game design
            if(collision.gameObject.GetComponent<PlayerDeath>().isDead == false)
            {
                collision.gameObject.GetComponent<PlayerDeath>().OnDeath();
            }
        }
    }

    public void OnDeath()
    {
        // Actions to let enemy die, depends on the game design
        // Currently we just destroy the enemy
        Destroy(gameObject);
    }
}
