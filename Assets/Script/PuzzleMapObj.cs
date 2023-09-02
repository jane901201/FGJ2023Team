using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleMapObj : MonoBehaviour
{
    [SerializeField] private bool controlable;
    [SerializeField] private PuzzleMapObjBeheavier beheavier;

    public bool Controlable { get => controlable; set => controlable = value; }


    public virtual void Up()
    {
        beheavier?.Up(this);
    }
    public virtual void Down()
    {
        beheavier?.Down(this);
    }
    public virtual void Left()
    {
        beheavier?.Left(this);
    }
    public virtual void Right()
    {
        beheavier?.Right(this);
    }

    public void MoveUp()
    {
        transform.position += Vector3.forward * PuzzleManager.GRID_SIZE;
    }
    public void MoveDown()
    {
        transform.position += Vector3.back * PuzzleManager.GRID_SIZE;
    }
    public void MoveLeft()
    {
        transform.position += Vector3.left * PuzzleManager.GRID_SIZE;
    }
    public void MoveRight()
    {
        transform.position += Vector3.right * PuzzleManager.GRID_SIZE;
    }
}
