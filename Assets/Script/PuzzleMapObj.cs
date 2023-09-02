using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PuzzleMapObj : MonoBehaviour
{
    [SerializeField] private bool controlable;
    [SerializeField] private bool blockObj;
    [SerializeField] private PuzzleMapObjBehavior beheavier;
    [SerializeField] private PuzzleMapObjBehavior passtiveBeheavier;

    public bool Controlable { get => controlable; set => controlable = value; }
    public bool BlockObj { get => blockObj; set => blockObj = value; }

    public virtual void DoDirection(Direction dir, bool isPasstive)
    {
        switch (dir)
        {
            case Direction.Up:
                Up(isPasstive);
                break;
            case Direction.Down:
                Down(isPasstive);
                break;
            case Direction.Left:
                Left(isPasstive);
                break;
            case Direction.Right:
                Right(isPasstive);
                break;
        }
    }
    public virtual void Up(bool isPasstive = false)
    {
        if (isPasstive)
        {
            passtiveBeheavier?.Up(this);
        }
        else
        {
            beheavier?.Up(this);
        }
    }
    public virtual void Down(bool isPasstive = false)
    {
        if (isPasstive)
        {
            passtiveBeheavier?.Down(this);
        }
        else
        {
            beheavier?.Down(this);
        }
    }
    public virtual void Left(bool isPasstive = false)
    {
        if (isPasstive)
        {
            passtiveBeheavier?.Left(this);
        }
        else
        {
            beheavier?.Left(this);
        }
    }
    public virtual void Right(bool isPasstive = false)
    {
        if (isPasstive)
        {
            passtiveBeheavier?.Right(this);
        }
        else
        {
            beheavier?.Right(this);
        }
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
    public void PushWithVector(Direction dir)
    {
        Vector3 moveTarget = transform.position + dir.GetVector();
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
        {
            if (current.BlockObj)
            {
                current.DoDirection(dir, true);
            }
        }
    }
}
