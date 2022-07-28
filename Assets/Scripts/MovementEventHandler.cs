public delegate void MovementDelegate(float xInput, float yInput);

public static class MyEventHandler
{
    // Movement Event
    public static event MovementDelegate MovementEvent;

    // Movement Event Call For Publishers
    public static void CallMovementEvent(float xInput, float yInput)
    {
        MovementEvent?.Invoke(xInput, yInput);
    }
}