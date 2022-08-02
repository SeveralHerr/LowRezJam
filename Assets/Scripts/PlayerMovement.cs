using UnityEngine;
public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        //if (movement.x != 0 || movement.y != 0)
        //{
        //    if (movement.x < 0)
        //    {
        //        Player.Instance.Direction = Direction.Left; 
        //    }
        //    else if (movement.x > 0)
        //    {
        //        Player.Instance.Direction = Direction.Right;
        //    }
        //    else if (movement.y < 0)
        //    {
        //        Player.Instance.Direction = Direction.Down;
        //    }
        //    else
        //    {
        //        Player.Instance.Direction = Direction.Up;
        //    }
        //}
    }

    private void FixedUpdate()
    {
        
        Player.Instance.MovePosition(movement);
    }


}