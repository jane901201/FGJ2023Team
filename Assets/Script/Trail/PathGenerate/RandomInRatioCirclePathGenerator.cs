using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInRatioCirclePathGenerator : PathGeneratorBase
{
    [SerializeField] private float radiusRatio = 1;

    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        float radius = Vector3.Distance(start, target) * radiusRatio;
        return target + (Vector3)Random.insideUnitCircle * radius;
    }
}
