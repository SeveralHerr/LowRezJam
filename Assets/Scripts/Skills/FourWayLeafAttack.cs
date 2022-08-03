using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FourWayLeafAttack : MonoBehaviour, ISkill
{
    public GameObject leafAttackPrefab;

    private float nextWaveSpawnTimer;
    public float waveTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        nextWaveSpawnTimer = 3f;

        leafAttackPrefab = Resources.Load("Prefabs/LeafAttack") as GameObject;
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
        var obj = leafAttackPrefab.GetComponent<Projectile>();
        var positionOffset =  Player.Instance.Position + new Vector2(1, 1);

        obj.Create(positionOffset, new Vector2(1, 0), Player.Instance.ProjectileAttackSpeed, 0);
        obj.Create(positionOffset, new Vector2(-1, 0), Player.Instance.ProjectileAttackSpeed, 0);
        obj.Create(positionOffset, new Vector2(0, 1), Player.Instance.ProjectileAttackSpeed, 90);
        obj.Create(positionOffset, new Vector2(0, -1), Player.Instance.ProjectileAttackSpeed, 90);
    }

    public void LearnSkill()
    {
        Player.Instance.gameObject.AddComponent<FourWayLeafAttack>();
    }
}
