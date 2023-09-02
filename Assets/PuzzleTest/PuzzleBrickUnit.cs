using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleBrickUnit : MonoBehaviour
{
    //private PuzzleMapGrid overlayGrid;
    //private PuzzleMapGrid occupyGrid;

    //public PuzzleMapGrid OccupyGrid
    //{
    //    get => occupyGrid;
    //    set
    //    {
    //        if (occupyGrid != null)
    //        {
    //            occupyGrid.OccupyedBy = null;
    //        }
    //        occupyGrid = value;
    //        if (occupyGrid != null)
    //        {
    //            occupyGrid.OccupyedBy = this;
    //        }
    //    }
    //}
    //public PuzzleMapGrid OverlayGrid
    //{
    //    get => overlayGrid;
    //    set
    //    {
    //        if (overlayGrid == value)
    //        {
    //            return;
    //        }

    //        if (overlayGrid != null)
    //        {
    //            overlayGrid.OverlayExit(this);
    //        }
    //        overlayGrid = value;
    //        if (overlayGrid != null)
    //        {
    //            overlayGrid.OverlayEnter(this);
    //        }
    //    }
    //}

    //public bool IsPointTouched(Vector2 pos)
    //{
    //    if (Mathf.Abs(transform.position.x - pos.x) < PuzzleManager.GRID_SIZE / 2 
    //        && Mathf.Abs(transform.position.y - pos.y) < PuzzleManager.GRID_SIZE / 2)
    //    {
    //        return true;
    //    }
    //    else
    //    {
    //        return false;
    //    }
    //}
    //public bool CheckGridCanPut()
    //{
    //    PuzzleMapGrid touchedGrid = PuzzleManager.instance.CurrentMap.FindGrid(transform.position);
    //    OverlayGrid = touchedGrid;
    //    if (touchedGrid == null)
    //    {
    //        return false;
    //    }
    //    else
    //    {
    //        return !touchedGrid.IsOccupyed;
    //    }
    //}
    //public void OnTakeUp()
    //{
    //    OccupyGrid = null;
    //}
    //public void SetToMap()
    //{
    //    OccupyGrid = PuzzleManager.instance.CurrentMap.FindGrid(transform.position);
    //}
    //public void ResetOverlay()
    //{
    //    OverlayGrid = null;
    //}
}
