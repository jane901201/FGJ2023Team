using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMap : MonoBehaviour
{
    [SerializeField] private List<PuzzleMapGrid> grids;

    private Dictionary<Vector2, PuzzleMapGrid> gridDict = new Dictionary<Vector2, PuzzleMapGrid>();



    private void Start()
    {
        foreach (PuzzleMapGrid current in grids)
        {
            if (gridDict.ContainsKey(current.transform.localPosition))
            {
                Debug.LogError("REPEAT COORDINATE: " + current.gameObject);
                continue;
            }

            gridDict.Add(current.transform.localPosition, current);
        }
    }
    public PuzzleMapGrid FindGrid(Vector2 pos)
    {
        Vector2 coordinate = MathTools.FindCoordinate(pos - (Vector2)transform.position, PuzzleManager.GRID_SIZE);
        if (!gridDict.ContainsKey(coordinate))
        {
            return null;
        }
        return gridDict[coordinate];
    }
#if UNITY_EDITOR
    [ContextMenu("Update Grids")]
    public void UpdateGrids()
    {
        grids.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            Transform current = transform.GetChild(i);
            PuzzleMapGrid currentGrid = current.GetComponent<PuzzleMapGrid>();

            if (currentGrid != null)
            {
                grids.Add(currentGrid);

                Vector3 coordinate = MathTools.FindCoordinate(current.localPosition, PuzzleManager.GRID_SIZE);
                current.localPosition = coordinate;
            }
        }
        UnityEditor.EditorUtility.SetDirty(gameObject);
    }
#endif
}
