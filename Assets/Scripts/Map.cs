using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : SingletonMonobehavior<Map>
{
    // Need to figure out how to find these dynamically
    private int MaxX = 80;
    private int MinX = -154;
    private int MinY = -52;
    private int MaxY = 62;

    public bool IsOutOfBounds(Vector2 position)
    {
        if(position.x >= MaxX)
        {
            return true;
        }

        if(position.x <= MinX)
        {
            return true;
        }

        if(position.y >= MaxY)
        {
            return true;
        }

        if(position.y <= MinY)
        {
            return true;
        }

        return false;
    }
}
