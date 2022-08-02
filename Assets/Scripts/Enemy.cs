using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    public GameObject player;
    public float speed;
    private Rigidbody2D rb;

    public void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        MoveTowardsPlayer();
    }

    private void MoveTowardsPlayer()
    {
        var playerPosition = player.transform.position;
        var moveDirection = playerPosition - transform.position;
        MoveTo(moveDirection);
    }

    public void MoveTo(Vector2 position)
    {
        var move = new Vector2(position.x * speed * Time.deltaTime, position.y * speed * Time.deltaTime);
        //move = PixelPerfectClamp(move, 0.1f);
        rb.MovePosition(rb.position + move);
    }

    private Vector2 PixelPerfectClamp(Vector2 moveVector, float pixelsPerUnit)
    {
        var vectorInPixels = new Vector2(Mathf.RoundToInt(moveVector.x * pixelsPerUnit), Mathf.RoundToInt(moveVector.y * pixelsPerUnit));

        return vectorInPixels / pixelsPerUnit;
    }
}
