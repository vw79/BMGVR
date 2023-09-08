using System.Collections;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Animation State Names")]
    [SerializeField] private string idleAnimation = "Zombie Idle"; 
    [SerializeField] private string attackAnimation = "Zombie Attack"; 

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Start the enemy behavior loop.
        StartCoroutine(EnemyBehaviorLoop());
    }

    private IEnumerator EnemyBehaviorLoop()
    {
        while (true) // This will keep the loop running indefinitely.
        {
            // Attack state.
            animator.Play(attackAnimation);
            yield return new WaitForSeconds(5.0f); // Attack for 5 seconds.

            // Idle state.
            animator.Play(idleAnimation);
            yield return new WaitForSeconds(5.0f); // Idle for 5 seconds.
        }
    }
}
