using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiSingleBehavior : SingleBehavior
{
    [SerializeField] private List<SingleBehavior> behaviorList;

    public override void DoBehavior(PuzzleMapObj obj)
    {
        foreach (SingleBehavior current in behaviorList)
        {
            current.DoBehavior(obj);
        }
    }
}
