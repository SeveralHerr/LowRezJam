using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonMonobehavior<Player>
{
    public GameObject projectile;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var obj = projectile.GetComponent<Projectile>();
            obj.Create(GetPosition(), new Vector2(1, 0));
        }

    }
}
