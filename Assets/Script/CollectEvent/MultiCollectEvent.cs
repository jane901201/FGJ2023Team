using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MultiCollectEvent : CollectEvent
{
    [SerializeField] private List<CollectEvent> events;

    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        foreach (CollectEvent current in events)
        {
            current.DoCollect(collector, obj);
        }
        base.DoCollect(collector, obj);
    }
}
