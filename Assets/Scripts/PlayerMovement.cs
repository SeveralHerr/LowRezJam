using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float speed = 1f;

    public Rigidbody2D rb;

    Vector2 movement;

    public GameObject gameOverPrefab;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        rb.MovePosition(rb.position + movement * speed);
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