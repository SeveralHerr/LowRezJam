using UnityEngine;

public class MovementBehavior : MonoBehaviour
{
    private Rigidbody2D rb;

    [field: SerializeField] 
    public float MovementSpeed { get; set; }

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void MoveTowards(Vector2 position)
    {
        var move = new Vector2(position.x * MovementSpeed * Time.deltaTime, position.y * MovementSpeed * Time.deltaTime);
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