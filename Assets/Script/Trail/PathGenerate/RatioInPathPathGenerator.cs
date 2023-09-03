using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RatioInPathPathGenerator : PathGeneratorBase
{
    [SerializeField] private float ratio;

    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        return Vector3.Lerp(start, target, ratio);
    }
}
