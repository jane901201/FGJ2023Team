using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleMapObj : MonoBehaviour
{
    [SerializeField] private bool controlable;
    [SerializeField] private bool blockObj;
    [SerializeField] private PuzzleMapObjBehavior beheavier;

    public bool Controlable { get => controlable; set => controlable = value; }
    public bool BlockObj { get => blockObj; set => blockObj = value; }

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
        MoveWithVector(Vector3.forward * PuzzleManager.GRID_SIZE);
    }
    public void MoveDown()
    {
        MoveWithVector(Vector3.back * PuzzleManager.GRID_SIZE);
    }
    public void MoveLeft()
    {
        MoveWithVector(Vector3.left * PuzzleManager.GRID_SIZE);
    }
    public void MoveRight()
    {
        MoveWithVector(Vector3.right * PuzzleManager.GRID_SIZE);
    }
    public void MoveWithVector(Vector3 moveVector)
    {
        Vector3 moveTarget = transform.position + moveVector;
        bool beBlock = false;
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
        {
            if (current.BlockObj)
            {
                beBlock = true;
            }
        }
        if (!beBlock)
        {
            transform.position += moveVector;
        }
    }
    public void PushWithVector(Vector3 pushVector)
    {
        Vector3 moveTarget = transform.position + pushVector;
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
        {
            if (current.BlockObj)
            {
                current.MoveWithVector(pushVector);
            }
        }
    }
}
