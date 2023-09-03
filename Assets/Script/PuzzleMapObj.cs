using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;
using UnityEngine.Serialization;

public class PuzzleMapObj : MonoBehaviour
{
    [SerializeField] private int controlIndex = -1;
    [SerializeField] private bool blockObj;
    [FormerlySerializedAs("wallBlockObj")] [SerializeField] private bool isWallBlockObj;
    [SerializeField] private bool collectable;
    [SerializeField] private PuzzleMapObjBehavior beheavier;
    [SerializeField] private PuzzleMapObjBehavior passtiveBeheavier;
    [SerializeField] private SingleBehavior undoBeheavier;
    [SerializeField] private SingleBehavior fallBeheavier;
    [SerializeField] private SingleBehavior fillBeheavier;
    [SerializeField] private CollectEvent powerUpFunction;

    public int ControlIndex { get => controlIndex; set => controlIndex = value; }
    public bool BlockObj { get => blockObj; set => blockObj = value; }
    public bool IsWallBlockObj
    {
        get => isWallBlockObj; set => isWallBlockObj = value;
    }

    public bool CanControl(int controlIndex)
    {
        return this.controlIndex == controlIndex;
    }
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
    public void Undo()
    {
        undoBeheavier?.DoBehavior(this);
    }
    public void Fall()
    {
        fallBeheavier?.DoBehavior(this);
    }
    public void Fill()
    {
        fillBeheavier?.DoBehavior(this);
    }
    public void BeCollect(PuzzleMapObj collector)
    {
        powerUpFunction?.OnCollect(collector, this);
    }
    public void DestroyInstance()
    {
        PuzzleManager.instance.CurrentMap.RemoveObj(this);
        Destroy(gameObject);
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

    /// <summary>
    /// TODO:
    /// </summary>
    public void JumpBack()
    {
        JumpWithVector(Vector3.left * PuzzleManager.GRID_SIZE);
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
            if (collectable)
            {
                foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
                {
                    current.BeCollect(this);
                }
            }
        }
    }
    public void JumpWithVector(Vector3 moveVector)
    {
        Vector3 checkMiddlePath = transform.position + moveVector;
        Vector3 moveTarget = transform.position + moveVector * 2;
        bool beBlock = false;
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(checkMiddlePath))
        {
            if (current.IsWallBlockObj)
            {
                beBlock = true;
            }
        }
        foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
        {
            if (current.IsWallBlockObj)
            {
                beBlock = true;
            }
        }
        if (!beBlock)
        {
            transform.position += moveVector * 2;
            if (collectable)
            {
                foreach (PuzzleMapObj current in PuzzleManager.instance.CurrentMap.FindObjs(moveTarget))
                {
                    current.BeCollect(this);
                }
            }
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
