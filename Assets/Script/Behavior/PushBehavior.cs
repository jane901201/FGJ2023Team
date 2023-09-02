using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBehavior : PuzzleMapObjBehavior
{
    public override void Up(PuzzleMapObj obj)
    {
        obj.PushWithVector(Direction.Up);
    }
    public override void Down(PuzzleMapObj obj)
    {
        obj.PushWithVector(Direction.Down);
    }
    public override void Left(PuzzleMapObj obj)
    {
        obj.PushWithVector(Direction.Left);
    }
    public override void Right(PuzzleMapObj obj)
    {
        obj.PushWithVector(Direction.Right);
    }
}
