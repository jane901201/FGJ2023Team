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
}