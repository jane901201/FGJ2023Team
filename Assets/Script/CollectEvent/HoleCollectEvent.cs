using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HoleCollectEvent : CollectEvent
{
    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        base.DoCollect(collector, obj);
        collector.Fall();
    }
}
