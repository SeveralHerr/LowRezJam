using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : SingletonUnitBase<Player>
{
    public GameObject projectile;
    public GameObject gameOverPrefab;

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    // Update is called once per frame
    public override void Update()
    {
        if(Input.GetMouseButtonDown(0))
        {
            var obj = projectile.GetComponent<Projectile>();

            // fires out of mouth
            var positionOffset = GetPosition() + new Vector2(1, 1);

            obj.Create(positionOffset, new Vector2(1, 0));
        }

        base.Update();
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
