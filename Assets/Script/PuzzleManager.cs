using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public const float GRID_SIZE = 1;

    public static PuzzleManager instance;

    [SerializeField] private List<PuzzleMap> stageMaps;

    private int currentStage;

    public PuzzleMap CurrentMap { get => stageMaps[currentStage]; }

    private void Start()
    {
        instance = this;
    }
    public void NextStage()
    {
        stageMaps[currentStage].gameObject.SetActive(false);
        currentStage++;
        stageMaps[currentStage].gameObject.SetActive(true);
    }
}
