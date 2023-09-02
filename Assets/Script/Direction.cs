using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Up,
    Down,
    Left,
    Right
}

public static class DirectionTool
{
    public static Vector3 GetVector(this Direction dir)
    {
        switch (dir)
        {
            case Direction.Up:
                return Vector3.forward;
            case Direction.Down:
                return Vector3.back;
            case Direction.Left:
                return Vector3.left;
            case Direction.Right:
                return Vector3.right;
        }
        return Vector3.zero;
    }
}