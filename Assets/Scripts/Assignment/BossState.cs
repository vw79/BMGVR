using System.Collections;
using UnityEngine;

public class BossState : MonoBehaviour
{
    [Header("Animation State Names")]
    [SerializeField] private string idleAnimation = "Zombie Idle"; 
    [SerializeField] private string attackAnimation = "Zombie Attack";

    [SerializeField] private Material[] materials = new Material[2];
    [SerializeField] private Renderer meshRenderer;

    private Animator animator;

    private void Start()
    {
        animator = GetComponent<Animator>();

        // Start the enemy behavior loop.
        StartCoroutine(EnemyBehaviorLoop());
    }

    private IEnumerator EnemyBehaviorLoop()
    {
        while (true) 
        {
            // Attack state.
            animator.Play(attackAnimation);
            yield return new WaitForSeconds(1.0f);

            SpawnALotOfEnemies();
            yield return new WaitForSeconds(2.0f);
            // Idle state.
            animator.Play(idleAnimation);
            yield return new WaitForSeconds(5.0f); 
        }
    }

    private void SpawnALotOfEnemies()
    {
        int spawnCount = Random.Range(10, 15);
        for (int i = 0; i < spawnCount; i++)
        {
            GameObject.Find("EnemySpawner").GetComponent<EnemySpawner>().SpawnEnemy();
        }
    }

    public void Injured()
    {
        meshRenderer.material = materials[1];
        Invoke("EndInjured", 0.1f);
    }

    public void EndInjured()
    {
        meshRenderer.material = materials[0];
    }

    public void OnDeath()
    {
        // Stop the enemy behavior loop.
        StopAllCoroutines();

        // Play the death animation.
        Destroy(gameObject);
    }
}
