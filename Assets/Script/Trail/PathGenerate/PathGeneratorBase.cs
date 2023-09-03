using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PathGeneratorBase : MonoBehaviour
{
    [SerializeField] private PathGeneratorBase next;

    public Vector3 GeneratePathPoint(Vector3 start, Vector3 target)
    {
        Vector3 currentTarget = GenerateCurrentPathPoint(start, target);
        if (next != null)
        {
            currentTarget = next.GeneratePathPoint(start, currentTarget);
        }
        return currentTarget;
    }
    protected abstract Vector3 GenerateCurrentPathPoint(Vector3 start, Vector3 target);
}
