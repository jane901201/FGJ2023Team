using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignDistancePathGenerator : PathGeneratorBase
{
    [SerializeField] private float distance;

    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        Vector3 offset = target - start;
        offset *= distance / offset.magnitude;
        return start + offset;
    }
}
