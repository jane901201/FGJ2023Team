using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInCirclePathGenerator : PathGeneratorBase
{
    [SerializeField] private bool onCircle;
    [SerializeField] private float circleRadius;

    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        Vector3 dir = Random.insideUnitCircle;
        if (onCircle)
        {
            dir = dir.normalized;
        }
        return target + dir * circleRadius;
    }
}
