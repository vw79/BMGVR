using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private GameObject enemyPrefab;
    [SerializeField] private float spawnInterval = 1f;

    private void Start()
    {
        StartCoroutine(SpawnEnemy());
    }

    private IEnumerator SpawnEnemy()
    {
        while(true)
        {
            Instantiate(enemyPrefab, GetRandomPosition(), Quaternion.identity);
            yield return new WaitForSeconds(spawnInterval);
        }
    }

    private Vector3 GetRandomPosition()
    {
        float x = Random.Range(-10f, 10f);
        float y = Random.Range(10f, 20f);
        float z = Random.Range(-10f, 10f);
        return new Vector3(x, y, z);
    }

    public void OnDisable()
    {
        StopAllCoroutines();
        this.enabled = false;
    }
}
