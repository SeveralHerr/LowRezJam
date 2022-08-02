using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    Vector2 movement;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");
    }

    private void FixedUpdate()
    {
        
        Player.Instance.MovePosition(movement);
    }


}