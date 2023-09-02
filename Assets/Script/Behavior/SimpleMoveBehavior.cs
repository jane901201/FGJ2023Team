using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveBehavior : PuzzleMapObjBehavior
{
    public override void Up(PuzzleMapObj obj)
    {
        obj.MoveUp();
    }
    public override void Down(PuzzleMapObj obj)
    {
        obj.MoveDown();
    }
    public override void Left(PuzzleMapObj obj)
    {
        obj.MoveLeft();
    }
    public override void Right(PuzzleMapObj obj)
    {
        obj.MoveRight();
    }
}
