using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InverseDirectionPathGenerator : PathGeneratorBase
{
    protected override Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target)
    {
        return start + (start - target);
    }
}
