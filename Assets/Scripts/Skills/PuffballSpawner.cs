using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuffballSpawner : MonoBehaviour, ISkill
{
    public GameObject puffballPrefab;

    private float timer;
    public float waveTimer = 10f;

    // Start is called before the first frame update
    void Start()
    {
        timer = 3f;

        puffballPrefab = Resources.Load($"Prefabs/{nameof(Puffball)}") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnProjectiles();
            timer = waveTimer;
        }
    }


    private void SpawnProjectiles()
    {
        var obj = puffballPrefab.GetComponent<Puffball>();
        var positionOffset = Player.Instance.Position + new Vector2(1, 1);

        obj.Create(positionOffset, new Vector2(1, 0), Player.Instance.ProjectileAttackSpeed / 2);
        obj.Create(positionOffset, new Vector2(-1, 0), Player.Instance.ProjectileAttackSpeed / 2);
        obj.Create(positionOffset, new Vector2(0, 1), Player.Instance.ProjectileAttackSpeed / 2);
        obj.Create(positionOffset, new Vector2(0, -1), Player.Instance.ProjectileAttackSpeed / 2);
    }

    public void LearnSkill()
    {
        Player.Instance.gameObject.AddComponent<PuffballSpawner>();
    }
}
