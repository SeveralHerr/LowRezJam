using System.Collections;
using System.Collections.Generic;
using UnityEngine;

//public class Directions
//{
//    public (bool x, bool y) Direction;
//}

//public enum Direction
//{
//    North, 
//    East,
//    South,
//    West
//}

//public static class Extenstions
//{
//    public static Direction GetDirection(this Vector2 vector)
//    {
//        if()
//    }
//}

public class Projectile : MonoBehaviour
{
    private Rigidbody2D rb;
   // private GameObject Target { get; set; }

    public Object Prefab;

    public float speed;

    private Vector2 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        //Prefab = this.gameObject;
        rb = GetComponent<Rigidbody2D>();
    }

    //public void SetTarget(GameObject target)
    //{
    //    Target = target;
    //}

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == null )
        {
            return;
        }

        //var moveTo = (Direction - GetPosition().normalized).normalized;
        MoveTo(Direction);
    }
    private Vector2 GetPosition()
    {
        return transform.position;
    }

    public Projectile Create(Vector2 initialPosition, Vector2 direction)
    {
        var newObject = Instantiate(Prefab, initialPosition, Quaternion.identity) as GameObject;
        var obj = newObject.GetComponent<Projectile>();
        obj.SetDirection(direction);
        //obj.SetTarget(target);
        return obj;
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
            Destroy(collision.gameObject);
            Destroy(gameObject);
        }
    }
}
