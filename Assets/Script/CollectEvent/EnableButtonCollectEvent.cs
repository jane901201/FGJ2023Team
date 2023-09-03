using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnableButtonCollectEvent : CollectEvent
{
    [SerializeField] private EnabledButton enableTarget;

    public override void DoCollect(PuzzleMapObj collector, PuzzleMapObj obj)
    {
        switch (enableTarget)
        {
            case EnabledButton.Up:
                PuzzleManager.instance.EnableUp();
                break;
            case EnabledButton.Down:
                PuzzleManager.instance.EnableDown();
                break;
            case EnabledButton.Undo:
                PuzzleManager.instance.EnableUndo();
                break;
            case EnabledButton.Char:
                PuzzleManager.instance.EnableChar();
                break;
            case EnabledButton.Goal:
                PuzzleManager.instance.EnableGoal();
                break;
        }
        base.DoCollect(collector, obj);
    }
}

public enum EnabledButton
{
    Up,
    Down,
    Undo,
    Char,
    Goal
}