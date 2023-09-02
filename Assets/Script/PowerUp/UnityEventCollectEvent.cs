using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class UnityEventCollectEvent : CollectEvent
{
    [SerializeField] private UnityEvent onPower;

    public override void OnCollect(PuzzleMapObj obj)
    {
        onPower.Invoke();
        base.OnCollect(obj);
    }
}
