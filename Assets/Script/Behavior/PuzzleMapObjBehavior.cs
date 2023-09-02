using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public abstract class PuzzleMapObjBehavior : MonoBehaviour
{
    public abstract void Up(PuzzleMapObj obj);
    public abstract void Down(PuzzleMapObj obj);
    public abstract void Left(PuzzleMapObj obj);
    public abstract void Right(PuzzleMapObj obj);
}
