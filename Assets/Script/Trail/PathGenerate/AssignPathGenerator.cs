using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AssignPathGenerator : PathGeneratorBase
{
    [SerializeField] private Vector3 assignedPoint;
    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        Vector3 result = start + assignedPoint;
        return result;
    }
}
