using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleObjCondition : MonoBehaviour
{
    public abstract bool CheckObj(PuzzleMapObj obj);
}
