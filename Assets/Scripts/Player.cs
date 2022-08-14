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
    public float ProjectileAttackSpeed = 0.5f;

    public bool IsPaused = false;

    public GameObject HatOne;
    public GameObject HatTwo;
    public GameObject HatThree;
    public GameObject HatFour;

    public Sprite blueGoobus;

    public GameObject Tank;
    public bool IsTankEnabled = false;

    // public SkillGroup SkillGroup;

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public override void Start()
    {
        //SkillGroup = new SkillGroup();
        base.Start();
    }

    // Update is called once per frame
    public override void Update()
    {
        if(IsPaused)
        {
            return;
        }

        if (Input.GetKey("escape"))
        {
            Application.Quit();
        }

        if (Input.GetMouseButtonDown(0))
        {
            FireProjectile();
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
        var isOffset = gameObject.GetComponentInChildren<GoobusFloater>().dir;
        var offset = 1;
        if (isOffset)
        {
            offset = 2;
        }
        var positionOffset = GetPosition() + new Vector2(1, offset);

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

    public void Dead()
    {
        DisplayGameOverScreen();
    }

    private void DisplayGameOverScreen()
    {
        gameOverPrefab.SetActive(true);
    }

    public void EnableHatOne()
    {
        HatOne.SetActive(true);
    }
    public void EnableHatTwo()
    {
        HatOne.SetActive(false);
        HatTwo.SetActive(true);
    }
    public void EnableHatThree()
    {
        HatTwo.SetActive(false);
        HatThree.SetActive(true);
    }

    public void EnableHatFour()
    {
        HatThree.SetActive(false);
        HatFour.SetActive(true);
    }

    public void EnableBlueGoobus()
    {
        var renderer = gameObject.GetComponentInChildren<SpriteRenderer>();
        renderer.sprite = blueGoobus;
    }

    public void EnableTank()
    {
        Tank.SetActive(true);
        IsTankEnabled = true;
        gameObject.GetComponentInChildren<GoobusFloater>().enabled = false;
    }

    private void OnTriggerEnter2D(Collider2D collision) 
    {
        //if (collision.CompareTag("Enemy"))
        //{

        //    var enemies = GameObject.FindGameObjectsWithTag("Enemy");
        //    foreach (var item in enemies)
        //    {
        //        Destroy(item.gameObject);
        //    }

            
        //}
    }
}
