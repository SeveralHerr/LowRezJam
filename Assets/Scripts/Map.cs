using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Map : SingletonMonobehavior<Map>
{
    // Need to figure out how to find these dynamically
    private int MaxX = 280;
    private int MinX = -354;
    private int MinY = -252;
    private int MaxY = 262;

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
