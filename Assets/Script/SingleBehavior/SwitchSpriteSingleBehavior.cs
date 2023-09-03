using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SwitchSpriteSingleBehavior : SingleBehavior
{
    [SerializeField] private SpriteRenderer targetSpriteRenderer;
    [SerializeField] private Sprite switchTo;

    public override void DoBehavior(PuzzleMapObj obj)
    {
        targetSpriteRenderer.sprite = switchTo;
    }
}
