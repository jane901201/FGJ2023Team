using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleMapGrid : MonoBehaviour
{
    [SerializeField] private GameObject overlayObj;

    private PuzzleBrickUnit occupyedBy;
    List<PuzzleBrickUnit> overlayObjs = new List<PuzzleBrickUnit>();

    public PuzzleBrickUnit OccupyedBy { get => occupyedBy; set => occupyedBy = value; }
    public bool IsOccupyed { get => OccupyedBy != null; }

    public void OverlayEnter(PuzzleBrickUnit overlayUnit)
    {
        if (overlayObjs.Contains(overlayUnit))
        {
            return;
        }
        overlayObjs.Add(overlayUnit);
        UpdateOverlayObj();
    }
    public void OverlayExit(PuzzleBrickUnit overlayUnit)
    {
        overlayObjs.Remove(overlayUnit);
        UpdateOverlayObj();
    }
    public void UpdateOverlayObj()
    {
        overlayObj.SetActive(overlayObjs.Count > 0);
    }
}
