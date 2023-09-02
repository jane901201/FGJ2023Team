using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventCollectEvent : CollectEvent
{
    [SerializeField] private UnityEvent onPower;

    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        onPower.Invoke();
        base.DoCollect(collector, obj);
    }
}
