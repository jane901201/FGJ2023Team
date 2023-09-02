using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEvent : MonoBehaviour
{
    [SerializeField] private bool destroyAfterCollect;
    [SerializeField] private PuzzleObjCondition condition; 

    public void OnCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        if (condition == null || condition.CheckObj(collector))
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
}
