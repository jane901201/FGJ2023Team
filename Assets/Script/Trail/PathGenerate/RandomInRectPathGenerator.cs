using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RandomInRectPathGenerator : PathGeneratorBase
{
    [SerializeField] private Vector3 rectSize;

    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        return target + Vector3.right * Random.Range(-0.5f, 0.5f) * rectSize.x + Vector3.up * Random.Range(-0.5f, 0.5f) * rectSize.y;
    }
}
