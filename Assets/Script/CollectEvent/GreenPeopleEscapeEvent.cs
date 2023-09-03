using UnityEngine;

public class GreenPeopleEscapeEvent : CollectEvent
{
    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        base.DoCollect(collector, obj);
        collector.Escape();
    }
}
