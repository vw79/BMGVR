using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float[] spawnInterval = new float[2];
    [SerializeField] private Vector3 minSpawnPosition;
    [SerializeField] private Vector3 maxSpawnPosition;

    private void Start()
    {
        StartCoroutine(SpawnEnemyTimer());

        //Ignore the collision between gun and enemy
        Physics.IgnoreLayerCollision(11,10);
    }

    private IEnumerator SpawnEnemyTimer()
    {
        while(true)
        {
            SpawnEnemy();
            yield return new WaitForSeconds(Random.Range(spawnInterval[0], spawnInterval[1]));
        }
    }

    public void SpawnEnemy()
    {
        Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
    }

    private Vector3 GetRandomPosition()
    {
        return new Vector3(Random.Range(minSpawnPosition.x, maxSpawnPosition.x), 
                           Random.Range(minSpawnPosition.y, maxSpawnPosition.y), 
                           Random.Range(minSpawnPosition.z, maxSpawnPosition.z));
    }

    public void OnDisable()
    {
        StopAllCoroutines();
        this.enabled = false;
    }
}
