using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimpleMoveBeheavier : PuzzleMapObjBeheavier
{
    public override void Up(PuzzleMapObj obj)
    {
        base.Up(obj);
        obj.MoveUp();
    }
    public override void Down(PuzzleMapObj obj)
    {
        base.Up(obj);
        obj.MoveDown();
    }
    public override void Left(PuzzleMapObj obj)
    {
        base.Up(obj);
        obj.MoveLeft();
    }
    public override void Right(PuzzleMapObj obj)
    {
        base.Up(obj);
        obj.MoveRight();
    }
}
