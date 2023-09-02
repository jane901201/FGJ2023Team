using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMap : MonoBehaviour
{
    [SerializeField] private List<PuzzleMapObj> objs;


    public List<PuzzleMapObj> FindObjs(Vector3 pos)
    {
        List<PuzzleMapObj> result = new List<PuzzleMapObj>();
        Vector3 coordinate = MathTools.FindCoordinate(pos, PuzzleManager.GRID_SIZE);
        foreach (PuzzleMapObj current in objs)
        {
            if (Vector3.Distance(current.transform.position, coordinate) < PuzzleManager.GRID_SIZE / 10)
            {
                result.Add(current);
            }
        }
        return result;
    }
    #region Control
    public void Up()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.Controlable)
            {
                current.Up();
            }
        }
    }
    public void Down()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.Controlable)
            {
                current.Down();
            }
        }
    }
    public void Left()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.Controlable)
            {
                current.Left();
            }
        }
    }
    public void Right()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.Controlable)
            {
                current.Right();
            }
        }
    }
    #endregion
#if UNITY_EDITOR
    [ContextMenu("Update Grids")]
    public void UpdateGrids()
    {
        objs.Clear();
        UpdateGridsForTransform(transform);
        UnityEditor.EditorUtility.SetDirty(gameObject);
    }
    public void UpdateGridsForTransform(Transform transform)
    {
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform current = transform.GetChild(i);
            PuzzleMapObj currentGrid = current.GetComponent<PuzzleMapObj>();

            if (currentGrid != null)
            {
                objs.Add(currentGrid);

                Vector3 coordinate = MathTools.FindCoordinate(current.position, PuzzleManager.GRID_SIZE);
                current.position = coordinate;
            }

            UpdateGridsForTransform(current);
        }
    }
#endif
}
