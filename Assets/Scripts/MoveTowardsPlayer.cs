using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoveTowardsPlayer : MonoBehaviour
{
    private GameObject player;
    public float speed;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        var playerList = GameObject.FindGameObjectsWithTag("Player");
        // fix for deleted character
        foreach(var item in playerList)
        {
            player = item;
        }
    }

    void Update()
    {
        MoveTowardsPlayerPosition();
    }

    private void MoveTowardsPlayerPosition()
    {
        var playerPosition = player.transform.position;
        var moveDirection = playerPosition - transform.position;
        MoveTo(moveDirection);
    }

    public void MoveTo(Vector2 position)
    {
        var move = new Vector2(position.x * speed * Time.deltaTime, position.y * speed * Time.deltaTime);

        rb.MovePosition(rb.position + move);
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
        }
    }
}
