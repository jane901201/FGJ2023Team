using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CollectEvent : MonoBehaviour
{
    [SerializeField] private bool destroyAfterCollect;

    public virtual void OnCollect(PuzzleMapObj obj)
    {
        if (destroyAfterCollect)
        {
            obj.DestroyInstance();
        }
    }
}
