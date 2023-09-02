using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ControlIndexCondition : PuzzleObjCondition
{
    [SerializeField] private int requestIndex;

    public override bool CheckObj(PuzzleMapObj obj)
    {
        return requestIndex == obj.ControlIndex;
    }
}
