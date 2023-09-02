using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBrick : MonoBehaviour
{
    [SerializeField] private List<PuzzleBrickUnit> units;

    private bool isDraging;
    private Vector2 startPos;
    private Vector2 dragOffset;

    private Vector3 MapRelativePos 
    {
        set => transform.position = value + PuzzleManager.instance.CurrentMap.transform.position;
        get => transform.position - PuzzleManager.instance.CurrentMap.transform.position; 
    }

    private void Start()
    {
        startPos = transform.position;
    }
    public void Update()
    {
        if (!isDraging && Input.GetMouseButtonDown(0))
        {
            foreach (PuzzleBrickUnit current in units)
            {
                if (current.IsPointTouched(Input.mousePosition))
                {
                    dragOffset = transform.position - Input.mousePosition;
                    isDraging = true;
                    foreach (PuzzleBrickUnit currentUnit in units)
                    {
                        currentUnit.OnTakeUp();
                    }
                    PuzzleManager.instance.PrintCurrentOccupy();
                    break;
                }
            }
        }
        if (isDraging)
        {
            if (Input.GetMouseButtonDown(1))
            {
                Rotation();
            }

            transform.position = (Vector2)Input.mousePosition + dragOffset;
            bool flag = CheckGrids();
            if (!Input.GetMouseButton(0))
            {
                isDraging = false;
                OnRelease();
                if (flag)
                {
                    SetToMap();
                }
                else
                {
                    ReturnToOrigin();
                }
                PuzzleManager.instance.PrintCurrentOccupy();
            }
        }
    }
    public void Rotation()
    {
        transform.rotation = Quaternion.AngleAxis(90, Vector3.forward) * transform.rotation;
    }
    public bool CheckGrids()
    {
        bool flag = true;
        foreach (PuzzleBrickUnit current in units)
        {
            if (!current.CheckGridCanPut())
            {
                flag = false;
            }
        }
        return flag;
    }
    public void SetToMap()
    {
        MapRelativePos = MathTools.FindCoordinate(MapRelativePos, PuzzleManager.GRID_SIZE);
        foreach (PuzzleBrickUnit current in units)
        {
            current.SetToMap();
        }
    }
    public void ReturnToOrigin()
    {
        transform.position = startPos;
    }
    public void OnRelease()
    {
        foreach (PuzzleBrickUnit current in units)
        {
            current.ResetOverlay();
        }
    }
#if UNITY_EDITOR
    [ContextMenu("Update Units")]
    public void UpdateUnits()
    {
        units.Clear();
        for (int i = 0; i < transform.childCount; i++)
        {
            RectTransform current = (RectTransform)transform.GetChild(i);
            PuzzleBrickUnit currentUnit = current.GetComponent<PuzzleBrickUnit>();

            if (currentUnit != null)
            {
                units.Add(currentUnit);

                Vector2 coordinate = MathTools.FindCoordinate(current.localPosition, PuzzleManager.GRID_SIZE);
                current.localPosition = coordinate;
            }
        }
        UnityEditor.EditorUtility.SetDirty(gameObject);
    }
#endif
}
