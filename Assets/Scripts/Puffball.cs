using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puffball : MonoBehaviour, ISkill
{
    public GameObject puffballPrefab;

    private float nextWaveSpawnTimer;
    public float waveTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        nextWaveSpawnTimer = 3f;

        puffballPrefab = Resources.Load("Prefabs/Puffball") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        nextWaveSpawnTimer -= Time.deltaTime;
        if (nextWaveSpawnTimer <= 0f)
        {
            SpawnProjectiles();
            nextWaveSpawnTimer = waveTimer;
        }
    }


    private void SpawnProjectiles()
    {
        var obj = puffballPrefab.GetComponent<Projectile>();
        var positionOffset = Player.Instance.Position + new Vector2(1, 1);

        obj.Create(positionOffset, new Vector2(1, 0), Player.Instance.ProjectileAttackSpeed, 0);
        obj.Create(positionOffset, new Vector2(-1, 0), Player.Instance.ProjectileAttackSpeed, 0);
        obj.Create(positionOffset, new Vector2(0, 1), Player.Instance.ProjectileAttackSpeed, 90);
        obj.Create(positionOffset, new Vector2(0, -1), Player.Instance.ProjectileAttackSpeed, 90);
    }

    public void LearnSkill()
    {
        Player.Instance.gameObject.AddComponent<Puffball>();
    }
}
