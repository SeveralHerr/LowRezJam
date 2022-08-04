using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Puffball : MonoBehaviour
{
    public GameObject prefab;

    public MovementBehavior MovementBehavior;

    private Vector2 Direction { get; set; }

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Direction == null)
        {
            return;
        }

        MovementBehavior.MoveTowards(Direction);

        PurgeWhenOutOfBounds();
    }

    public void PurgeWhenOutOfBounds()
    {
        if (Map.Instance.IsOutOfBounds(MovementBehavior.GetPosition()))
        {
            Destroy(gameObject);
        }
    }

    public Puffball Create(Vector2 initialPosition, Vector2 direction, float speed)
    {
        var newObject = Instantiate(prefab, initialPosition, Quaternion.identity) as GameObject;
        var obj = newObject.GetComponent<Puffball>();
        obj.MovementBehavior.MovementSpeed = speed;
        obj.SetDirection(direction);
        return obj;
    }

    public void SetDirection(Vector2 direction)
    {
        Direction = direction;
    }
}
