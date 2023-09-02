using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PowerUp : MonoBehaviour
{
    [SerializeField] private bool destroyAfterCollect;
    [SerializeField] private UnityEvent onPower;

    public void OnCollect(PuzzleMapObj obj)
    {
        onPower.Invoke();
        if (destroyAfterCollect)
        {
            obj.DestroyInstance();
        }
    }
}
