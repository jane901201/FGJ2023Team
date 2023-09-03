using UnityEngine;

public class UndoBehaviour : SingleBehavior
{
    [SerializeField] private PlayerAnim playerAnim;
    public override void DoBehavior(PuzzleMapObj obj)
    {
        obj.JumpBack(playerAnim.PlayerDir);
    }
}
