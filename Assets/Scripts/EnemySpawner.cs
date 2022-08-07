using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Enemy.Factory slimeFactory;
    public List<Transform> EnemySpawnPositions;
    private int NextWaveCount = 10;

    private ITimer Timer { get; set; }

    [Inject]
    public void Construct(ITimer timer, Enemy.Factory factory)
    {
        slimeFactory = factory;
        Timer = timer;
    }

    void Start()
    {
        Timer.RunOnceTimer(3f, () => SpawnEnemies());
    }

    private void SpawnEnemies()
    {
        var spawnPosition = (Vector2)EnemySpawnPositions[UnityEngine.Random.Range(0, EnemySpawnPositions.Count)].position;
        if(Player.Instance == null)
        {
            return;
        }

        for(var i = 0; i < NextWaveCount; i++)
        {
            var slime = slimeFactory.Create();
            slime.Position = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(0f, 10f);
        }

        NextWaveCount += 5;
    }

    void Update()
    {
        Timer.RunTimer(10f, () => SpawnEnemies());
    }

    public static Vector2 GetRandomDir()
    {

        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
}
