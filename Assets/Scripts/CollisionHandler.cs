using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public interface ICollisionHandler
{
    public void DestroyOnCollision(Collider2D collider, string tag);

    void DestroyOnCollisionWithAction(Collider2D collider, string tag, Action action);
}
public class CollisionHandler : ICollisionHandler
{
    public void DestroyOnCollision(Collider2D collider, string tag)
    {
        if (collider.CompareTag(tag))
        {
            Score.Instance.currentScore += 1;
            UnityEngine.Object.Destroy(collider.gameObject);
        }
    }

    public void DestroyOnCollisionWithAction(Collider2D collider, string tag, Action action)
    {
        if (collider.CompareTag(tag))
        {
            action.Invoke();
            UnityEngine.Object.Destroy(collider.gameObject);
        }
    }
}