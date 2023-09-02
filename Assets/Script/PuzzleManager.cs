using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public const float GRID_SIZE = 1;

    public static PuzzleManager instance;

    [SerializeField] private PuzzleMap defaultMap;

    private PuzzleMap currentMap;

    public PuzzleMap CurrentMap { get => currentMap; set => currentMap = value; }

    private void Start()
    {
        instance = this;
        CurrentMap = defaultMap;
    }
    public void Up()
    {
        CurrentMap.Up();
    }
    public void Down()
    {
        CurrentMap.Down();
    }
    public void Left()
    {
        CurrentMap.Left();
    }
    public void Right()
    {
        CurrentMap.Right();
    }
    public void SetControlIndex(int index)
    {
        CurrentMap.SetControlIndex(index);
    }

}
