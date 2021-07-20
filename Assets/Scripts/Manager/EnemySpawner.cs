using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public Transform[] spawnPoints;
    public GameObject enemyPrefab;
    public float spawnTime;

    private PlayerHealth player;
    // Start is called before the first frame update
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);
        player = FindObjectOfType<PlayerHealth>();
    }

    void Spawn()
    {
        if (player.currentHealth <= 0) return;

        int randomPoint = Random.Range(0, spawnPoints.Length);
        Instantiate(enemyPrefab, spawnPoints[randomPoint].position, spawnPoints[randomPoint].rotation);
    }
}
