using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class SingleBehavior : MonoBehaviour
{
    public abstract void DoBehavior(PuzzleMapObj obj);
}
