using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        SpawnEnemies();
    }

    private void SpawnEnemies()
    {
        var spawnPosition = new Vector2(40, 0);
        for(var i = 0; i < 10; i++)
        {
            var randomPosition = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(0f, 10f);
            Instantiate(enemy, randomPosition, Quaternion.identity);
        }
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public static Vector2 GetRandomDir()
    {

        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f)).normalized;
    }
}
