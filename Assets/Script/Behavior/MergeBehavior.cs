public class MergeBehavior : PuzzleMapObjBehavior
{
    public override void Up(PuzzleMapObj obj)
    {
        obj.BoxMerge();
    }

    public override void Down(PuzzleMapObj obj)
    {
        obj.BoxMerge();
    }

    public override void Left(PuzzleMapObj obj)
    {
        obj.BoxMerge();
    }

    public override void Right(PuzzleMapObj obj)
    {
        obj.BoxMerge();
    }
}
