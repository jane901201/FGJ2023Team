using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LevelClearCollectEvent : CollectEvent
{
    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        base.DoCollect(collector, obj);
        PuzzleManager.instance.LevelClear();
    }
}
