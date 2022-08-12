using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private BossSlime.Factory bossSlimeFactory;
    private Enemy.Factory slimeFactory;
    public List<Transform> EnemySpawnPositions;
    private int NextWaveCount = 10;

    private ITimer Timer { get; set; }
    private ITimer Timer2 { get; set; }

    [Inject]
    public void Construct(ITimer timer, ITimer timer2,  Enemy.Factory factory, BossSlime.Factory bossFactory)
    {
        slimeFactory = factory;
        bossSlimeFactory = bossFactory;
        Timer = timer;
        Timer2 = timer2;
          
    }

    void Start()
    {
        Timer.RunOnceTimer(3f, () => SpawnEnemies());
        Timer.RunOnceTimer(0f, () => SpawnEnemies());
    }

    private void SpawnEnemies()
    {
        var spawnPosition = (Vector2)EnemySpawnPositions[UnityEngine.Random.Range(0, EnemySpawnPositions.Count)].position;
        if(Player.Instance == null)
        {
            return;
        }

        for (var i = 0; i < NextWaveCount; i++)
        {
            var slime = slimeFactory.Create();
            slime.Position = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(0f, 10f);
        }

        NextWaveCount += 5;
    }

    private void SpawnBossEnemies()
    {
        var spawnPosition = (Vector2)EnemySpawnPositions[UnityEngine.Random.Range(0, EnemySpawnPositions.Count)].position;
        if (Player.Instance == null)
        {
            return;
        }

        var slime = bossSlimeFactory.Create();
        slime.Position = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(0f, 10f);
    }

    void Update()
    {
        if(Player.Instance.IsPaused)
        {
            return;
        }

        Timer.RunTimer(10f, () => SpawnEnemies());
        Timer2.RunTimer(20f, () => SpawnBossEnemies());
    }

    public static Vector2 GetRandomDir()
    {

        return new Vector2(UnityEngine.Random.Range(-1f, 1f), UnityEngine.Random.Range(-1f, 1f));
    }
}
