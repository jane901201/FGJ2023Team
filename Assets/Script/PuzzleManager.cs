using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PuzzleManager : MonoBehaviour
{
    public const float GRID_SIZE = 1;

    public static PuzzleManager instance;

    [SerializeField] private List<PuzzleMap> stageMaps;
    [SerializeField] private GameObject upObj;
    [SerializeField] private GameObject downObj;
    [SerializeField] private GameObject undoObj;
    [SerializeField] private GameObject charObj;
    [SerializeField] private GameObject goalObj;


    private int currentStage;

    public PuzzleMap currentMap;
    public PuzzleMap CurrentMap { get => currentMap; }

    private void Start()
    {
        instance = this;
        currentMap = Instantiate(stageMaps[currentStage]);
    }
    public void NextStage()
    {
        Destroy(currentMap);
        currentStage++;
        currentMap = Instantiate(stageMaps[currentStage]);
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
    public void Undo()
    {
        CurrentMap.Undo();
    }
    public void SwitchControl(int index)
    {
        CurrentMap.SetControlIndex(index);
    }
    public void EnableUp()
    {
        upObj.SetActive(true);
    }
    public void EnableDown()
    {
        downObj.SetActive(true);
    }
    public void EnableChar()
    {
        charObj.SetActive(true);
    }
    public void EnableGoal()
    {
        goalObj.SetActive(true);
    }
    public void EnableUndo()
    {
        undoObj.SetActive(true);
    }
}
