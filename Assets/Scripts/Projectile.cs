using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Projectile : MonoBehaviour
{
    public Object Prefab;

    public MovementBehavior MovementBehavior;

    private Vector2 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if(Direction == null )
        {
            return;
        }


        MovementBehavior.MoveTowards(Direction);

        PurgeWhenOutOfBounds();
    }

    public void PurgeWhenOutOfBounds()
    {
        if(Map.Instance.IsOutOfBounds( MovementBehavior.GetPosition() ))
        {
            Destroy(gameObject);
        }
    }

    public Projectile Create(Vector2 initialPosition, Vector2 direction, float speed, float rotation = 0f)
    {
        var newObject = Instantiate(Prefab, initialPosition, Quaternion.Euler(0f, 0f, rotation)) as GameObject;
        var obj = newObject.GetComponent<Projectile>();
        obj.MovementBehavior.MovementSpeed = speed;
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
            Score.Instance.IncrementScore();

            collision.gameObject.GetComponent<UnitBase>().Dead();

            if(!Player.Instance.HasPiercing)
            {
                Destroy(gameObject);
            }
        }
    }
}
