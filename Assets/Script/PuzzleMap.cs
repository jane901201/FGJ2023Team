using System;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMap : MonoBehaviour
{
    [SerializeField] private List<PuzzleMapObj> objs;
    [SerializeField] private int controlIndex;
    [SerializeField] private List<IndexObjList> enableWithControlIndexObjs;

    List<PuzzleMapObj> removedObjs = new List<PuzzleMapObj>();

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
    public void RemoveObj(PuzzleMapObj removed)
    {
        removedObjs.Add(removed);
    }
    public void UpdateObjList()
    {
        objs.RemoveAll((PuzzleMapObj a) =>
        {
            return removedObjs.Contains(a);
        });
        removedObjs.Clear();
    }
    #region Control
    public void SetControlIndex(int index)
    {
        controlIndex = index;
        for (int i = 0; i < enableWithControlIndexObjs.Count; i++)
        {
            foreach (GameObject currentObj in enableWithControlIndexObjs[i].objs)
            {
                currentObj.SetActive(enableWithControlIndexObjs[i].index == controlIndex);
            }
        }
    }
    public void Up()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.CanControl(controlIndex) && current.gameObject.activeInHierarchy)
            {
                current.Up();
            }
        }
        UpdateObjList();
    }
    public void Down()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.CanControl(controlIndex) && current.gameObject.activeInHierarchy)
            {
                current.Down();
            }
        }
        UpdateObjList();
    }
    public void Left()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.CanControl(controlIndex) && current.gameObject.activeInHierarchy)
            {
                current.Left();
            }
        }
        UpdateObjList();
    }
    public void Right()
    {
        foreach (PuzzleMapObj current in objs)
        {
            if (current.CanControl(controlIndex) && current.gameObject.activeInHierarchy)
            {
                current.Right();
            }
        }
        UpdateObjList();
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

[Serializable]
public class IndexObjList
{
    public int index;
    public List<GameObject> objs;
}