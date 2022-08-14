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
    public AudioSource tankSounds;

    private void Update()
    {
        movement.x = Input.GetAxisRaw("Horizontal");
        movement.y = Input.GetAxisRaw("Vertical");

        if ((movement.x != 0 || movement.y != 0) && !tankSounds.isPlaying && Player.Instance.IsTankEnabled)
        {
            tankSounds.Play();
           
        }
        else if (movement.x == 0 && movement.y == 0)
        {
            tankSounds.Stop();
        }
    }

    private void FixedUpdate()
    {
        
        Player.Instance.MovePosition(movement);
    }


}