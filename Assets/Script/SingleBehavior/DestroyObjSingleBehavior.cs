using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyObjSingleBehavior : SingleBehavior
{
    public override void DoBehavior(PuzzleMapObj obj)
    {
        obj.DestroyInstance();
    }
}
