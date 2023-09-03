public class MergeBehavior : PuzzleMapObjBehavior
{
    public override void Up(PuzzleMapObj obj)
    {
        obj.BoxMergeUp();
    }

    public override void Down(PuzzleMapObj obj)
    {
        obj.BoxMergeDown();
    }

    public override void Left(PuzzleMapObj obj)
    {
        obj.BoxMergeLeft();
    }

    public override void Right(PuzzleMapObj obj)
    {
        obj.BoxMergeRight();
    }
}
