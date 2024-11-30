using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemyPrefab;
    public Transform[] spawnPoints;
    public float spawnInterval = 2f; 

    private void Start()
    {
        InvokeRepeating(nameof(SpawnEnemy), spawnInterval, spawnInterval);
    }

    void SpawnEnemy()
    {
        int spawnIndex = Random.Range(0, spawnPoints.Length);
        Transform spawnPoint = spawnPoints[spawnIndex];

        GameObject enemy = Instantiate(enemyPrefab, spawnPoint.position, spawnPoint.rotation);

        SpriteRenderer renderer = enemy.GetComponent<SpriteRenderer>();
        if (Random.Range(0, 2) == 0)
        {
            renderer.color = Color.red;
        }
        else
        {
            renderer.color = Color.blue;
        }

        enemy.GetComponent<EnemyMovement>().Initialize(spawnPoint.position.x > 0 ? Vector2.left : Vector2.right);
    }
}
