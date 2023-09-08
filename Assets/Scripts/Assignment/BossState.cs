using System.Collections;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Animation State Names")]
    [SerializeField] private string idleAnimation = "Zombie Idle"; 
    [SerializeField] private string attackAnimation = "Zombie Attack"; 

    private Animator animator;
    [SerializeField] private float max_health = 2000f;
    private float current_health;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Start the enemy behavior loop.
        StartCoroutine(EnemyBehaviorLoop());
    }
    private void Awake()
    {
        current_health = max_health;
    }

    private IEnumerator EnemyBehaviorLoop()
    {
        while (true) 
        {
            // Attack state.
            animator.Play(attackAnimation);
            yield return new WaitForSeconds(3.0f); 

            // Idle state.
            animator.Play(idleAnimation);
            yield return new WaitForSeconds(5.0f); 
        }
    }

    public void TakeDamage(float damage)
    {
        {
            current_health -= damage;
        }

        if (current_health <= 0)
        {
            Destroy(gameObject);
        }
    }
}
