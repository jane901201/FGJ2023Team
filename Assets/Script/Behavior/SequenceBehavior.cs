using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SequenceBehavior : PuzzleMapObjBehavior
{
    [SerializeField] private List<PuzzleMapObjBehavior> behaviors;

    public override void Down(PuzzleMapObj obj)
    {
        foreach (PuzzleMapObjBehavior current in behaviors)
        {
            current.Down(obj);
        }
    }

    public override void Left(PuzzleMapObj obj)
    {
        foreach (PuzzleMapObjBehavior current in behaviors)
        {
            current.Left(obj);
        }
    }

    public override void Right(PuzzleMapObj obj)
    {
        foreach (PuzzleMapObjBehavior current in behaviors)
        {
            current.Right(obj);
        }
    }

    public override void Up(PuzzleMapObj obj)
    {
        foreach (PuzzleMapObjBehavior current in behaviors)
        {
            current.Up(obj);
        }
    }
}
