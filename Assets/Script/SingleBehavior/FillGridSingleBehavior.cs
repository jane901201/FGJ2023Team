using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FillGridSingleBehavior : SingleBehavior
{
    public override void DoBehavior(PuzzleMapObj obj)
    {
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(obj.transform.position))
        {
            current.Fill();
        }
    }
}
