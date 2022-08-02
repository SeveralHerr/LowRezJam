using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Object Prefab;

    public MovementBehavior MovementBehavior { get; set; }

    private Vector2 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        MovementBehavior = GetComponent<MovementBehavior>();
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == null )
        {
            return;
        }

        MovementBehavior.MoveTowards(Direction);
    }

    public Projectile Create(Vector2 initialPosition, Vector2 direction)
    {
        var newObject = Instantiate(Prefab, initialPosition, Quaternion.identity) as GameObject;
        var obj = newObject.GetComponent<Projectile>();
        obj.SetDirection(direction);
        return obj;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.CompareTag("Enemy"))
        {
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
