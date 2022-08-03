using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlantRingSpawner : MonoBehaviour, ISkill
{
    public GameObject plantRingPrefab;

    private float timer = 5f;


    // Start is called before the first frame update
    void Start()
    {
        plantRingPrefab = Resources.Load($"Prefabs/{nameof(PlantRing)}") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRing();
            timer = 5f;
        }
    }

    private void SpawnRing()
    {
        var obj = plantRingPrefab.GetComponent<PlantRing>();
        obj.Create(Player.Instance.Position);
    }

    public void LearnSkill()
    {
        Player.Instance.gameObject.AddComponent<PlantRingSpawner>();
    }
}