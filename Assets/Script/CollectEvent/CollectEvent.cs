using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEvent : MonoBehaviour
{
    [SerializeField] private bool destroyAfterCollect;
    [SerializeField] private PuzzleObjCondition condition;

    private bool enable = true;

    public void OnCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        if (enable && (condition == null || condition.CheckObj(collector)))
        {
            DoCollect(collector, obj);
        }
    }
    public virtual void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        if (destroyAfterCollect)
        {
            obj.DestroyInstance();
        }
    }
    public void DisableEvent()
    {
        enable = false;
    }
}
