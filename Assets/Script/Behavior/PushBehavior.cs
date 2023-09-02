using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PushBehavior : PuzzleMapObjBehavior
{
    public override void Up(PuzzleMapObj obj)
    {
        obj.PushWithVector(Vector3.forward * PuzzleManager.GRID_SIZE);
    }
    public override void Down(PuzzleMapObj obj)
    {
        obj.PushWithVector(Vector3.back * PuzzleManager.GRID_SIZE);
    }
    public override void Left(PuzzleMapObj obj)
    {
        obj.PushWithVector(Vector3.left * PuzzleManager.GRID_SIZE);
    }
    public override void Right(PuzzleMapObj obj)
    {
        obj.PushWithVector(Vector3.right * PuzzleManager.GRID_SIZE);
    }
}
