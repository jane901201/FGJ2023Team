using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierTrail : Trail
{
    public override Vector3 GetPosition(float t)
    {
        return GetBezierPosition(PathPoints, t);
    }
    public Vector3 GetBezierPosition(List<Vector3> path, float t)
    {
        if (path.Count == 1)
        {
            return path[0];
        }
        else
        {
            List<Vector3> nextPath = new List<Vector3>();
            for (int i = 0; i < path.Count - 1; i++)
            {
                nextPath.Add(Vector3.Lerp(path[i], path[i + 1], t));
            }
            return GetBezierPosition(nextPath, t);
        }
    }
}
