using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonUnitBase<Player>
{
    public GameObject projectile;
    public GameObject gameOverPrefab;
    public GameObject levelUpPrefab;

    public Direction Direction;

    public bool HasPiercing = false;
    public float ProjectileAttackSpeed = 150f;

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
      
        if(Input.GetMouseButtonDown(0))
        {
            FireProjectile();
        }

        if (Input.GetKeyDown(KeyCode.L))
        {
          levelUpPrefab.SetActive(true);
        }

        if(Input.GetKeyDown(KeyCode.P))
        {
            // pause
            if (Time.timeScale == 1)
            {
                Time.timeScale = 0;
            }
            else
            {
                Time.timeScale = 1;
            }
        }

        base.Update();
    }

    private void MouseDir()
    {
        var worldPosition = (Vector2)Camera.main.ScreenToWorldPoint(Input.mousePosition);
        var position = (worldPosition - Position).normalized;

        if (position.x > 0 && position.y < 0)
        {
            if(position.x > Mathf.Abs(position.y))
            {
                Direction = Direction.Right;
            }
            else
            {
                Direction = Direction.Down;
            }
        }
        if(position.x < 0 && position.y < 0)
        {
            if(Mathf.Abs(position.x) > Mathf.Abs(position.y))
            {
                Direction = Direction.Left;
            }
            else
            {
                Direction = Direction.Down;
            }
        }
        if(position.x > 0 && position.y > 0)
        {
            if(position.x > position.y)
            {
                Direction = Direction.Right;
            }
            else
            {
                Direction = Direction.Up;
            }
        }
        if(position.x < 0 && position.y > 0)
        {
            if(Mathf.Abs(position.x) > position.y)
            {
                Direction = Direction.Left;
            }
            else
            {
                Direction = Direction.Up;
            }
        }
    }

    private void FireProjectile()
    {
        MouseDir();
        var obj = projectile.GetComponent<Projectile>();

        // fires out of mouth
        var positionOffset = GetPosition() + new Vector2(1, 1);

        var direction = new Vector2();
        var rotation = 0f;
        if (Direction == Direction.Right)
        {
            direction = new Vector2(1, 0);
        }
        else if (Direction == Direction.Left)
        {
            direction = new Vector2(-1, 0);
        }
        else if (Direction == Direction.Up)
        {
            direction = new Vector2(0, 1);
            rotation = 90f;
        }
        else if (Direction == Direction.Down)
        {
            direction = new Vector2(0, -1);
            rotation = 90f;
        }

        obj.Create(positionOffset, direction, ProjectileAttackSpeed, rotation);
    }

 
    private void DisplayGameOverScreen()
    {
        gameOverPrefab.SetActive(true);
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        if (collision.CompareTag("Enemy"))
        {

            var enemies = GameObject.FindGameObjectsWithTag("Enemy");
            foreach (var item in enemies)
            {
                Destroy(item.gameObject);
            }


            var player = GameObject.FindGameObjectsWithTag("Player");
            foreach (var item in player)
            {
                Destroy(item.gameObject);
            }

            DisplayGameOverScreen();
        }
    }
}
