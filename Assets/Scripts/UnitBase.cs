using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UnitBase : MonoBehaviour
{
    private MovementBehavior MovementBehavior { get; set; }

    public float MovementSpeed { get { return MovementBehavior.MovementSpeed; } set { MovementBehavior.MovementSpeed = value; } }

    public Vector2 Position { get { return transform.position; } set { transform.position = value; } }


    // Start is called before the first frame update
    public virtual void Start()
    {
        MovementBehavior = GetComponent<MovementBehavior>();
    }

    // Update is called once per frame
    public virtual void Update()
    {
       
    }
    public void MovePosition(Vector2 movement)
    {
        MovementBehavior.MovePosition(movement);
    }

    public void MoveTowards(Vector2 position)
    {
        MovementBehavior.MoveTowards(position);
    }

    public void StopMovement()
    {
        MovementBehavior.MovementSpeed = 0;
    }


    public void MoveTowardsTarget(Vector2 source, Vector2 target)
    {
        var moveDirection = target - source;
        MovementBehavior.MoveTowards(moveDirection);
    }
}
