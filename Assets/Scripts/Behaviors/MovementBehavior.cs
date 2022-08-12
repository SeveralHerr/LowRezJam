using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Rigidbody2D rb;

    public float MovementSpeed;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowards(Vector2 position)
    {
        if(Player.Instance.IsPaused)
        {
            rb.velocity = Vector2.zero;
            return; 
        }
        var move = new Vector2(position.x * MovementSpeed * Time.fixedDeltaTime, position.y * MovementSpeed * Time.fixedDeltaTime);
        rb.MovePosition(rb.position + move);
    }

    public Vector2 GetPosition()
    {
        return transform.position;
    }

    public void ChangePosition(Vector2 position)
    {
        transform.position = position;
    }

    public void MovePosition(Vector2 movement)
    {
        rb.MovePosition(rb.position + movement * MovementSpeed);
    }
}