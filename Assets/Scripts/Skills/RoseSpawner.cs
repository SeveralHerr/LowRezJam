using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RoseSpawner : MonoBehaviour, ISkill
{
    public GameObject rosePrefab;

    private float timer = 3f;


    // Start is called before the first frame update
    void Start()
    {
        rosePrefab = Resources.Load($"Prefabs/{nameof(Rose)}") as GameObject;
    }

    // Update is called once per frame
    void Update()
    {
        timer -= Time.deltaTime;
        if (timer <= 0f)
        {
            SpawnRose();
            timer = 3f;
        }
    }

    private void SpawnRose()
    {
        var obj = rosePrefab.GetComponent<Rose>();
        obj.Create();
    }

    public void LearnSkill()
    {
        Player.Instance.gameObject.AddComponent<RoseSpawner>();
    }
}