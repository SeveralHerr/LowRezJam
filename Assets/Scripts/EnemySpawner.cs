using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private float nextWaveSpawnTimer;

    // Start is called before the first frame update
    void Start()
    {
        nextWaveSpawnTimer = 3f;
    }

    private void SpawnEnemies()
    {
        var spawnPosition = Player.Instance.Position;
        for(var i = 0; i < 10; i++)
        {
            var randomPosition = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(80f, 180f);
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        nextWaveSpawnTimer -= Time.deltaTime;
        if(nextWaveSpawnTimer <= 0f)
        {
            SpawnEnemies();
            nextWaveSpawnTimer = 10f;
        }
    }

    public static Vector2 GetRandomDir()
    {

        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
}
