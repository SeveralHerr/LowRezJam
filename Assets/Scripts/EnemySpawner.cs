using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class EnemySpawner : MonoBehaviour
{
    public GameObject enemy;
    private Enemy.Factory slimeFactory;

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
        var spawnPosition = Player.Instance.Position;
        if(Player.Instance == null)
        {
            return;
        }

        for(var i = 0; i < 10; i++)
        {
            var randomPosition = spawnPosition + GetRandomDir() * UnityEngine.Random.Range(80f, 180f);
            var slime = slimeFactory.Create();
            slime.Position = randomPosition;
        }
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
