using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class Trail : MonoBehaviour
{
    [SerializeField] private List<PathGeneratorBase> pathGenerators;

    private Vector3 startPos;
    private Vector3 endPos;
    private List<Vector3> pathPoints;
    private Transform endTransform;

    protected Vector3 StartPos { get => startPos; }
    protected Vector3 EndPos
    {
        get
        {
            if (endTransform != null)
            {
                return endTransform.position;
            }
            return endPos;
        }
    }
    protected List<Vector3> PathPoints
    {
        get
        {
            List<Vector3> result = new List<Vector3>(pathPoints);
            result.Add(EndPos);
            return result;
        }
    }

    public void GenerateTrail(Vector3 start, Vector3 end)
    {
        startPos = start;
        endPos = end;
        pathPoints = new List<Vector3>();
        pathPoints.Add(start);
        foreach (PathGeneratorBase current in pathGenerators)
        {
            Vector3 point = current.GeneratePathPoint(start, end);
            pathPoints.Add(point);
        }
        OnGenerate();
    }
    public void GenerateTrail(Vector3 start, Transform endTransform)
    {
        startPos = start;
        this.endTransform = endTransform;
        pathPoints = new List<Vector3>();
        pathPoints.Add(start);
        foreach (PathGeneratorBase current in pathGenerators)
        {
            Vector3 point = current.GeneratePathPoint(start, endTransform.position);
            pathPoints.Add(point);
        }
        OnGenerate();
    }
    public virtual void OnGenerate()
    {

    }
    public abstract Vector3 GetPosition(float t);
}
