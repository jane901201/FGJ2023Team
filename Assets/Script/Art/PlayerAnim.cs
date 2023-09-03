using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAnim : MonoBehaviour
{

    [SerializeField] bool handeler = false;

    [SerializeField] SpriteRenderer charaSprite;
    [SerializeField] Sprite walkUp1, walkUp2;

    [SerializeField] Sprite walkDown1, walkDown2;

    [SerializeField] Sprite walkLeft1, walkLeft2;

    [SerializeField] Sprite walkRight1, walkRight2;

    public Vector3 PlayerDir { get; set; } = Vector3.left;
    public void MoveUp()
    {
        if (handeler) charaSprite.sprite = walkUp1;
        else charaSprite.sprite = walkUp2;
        handeler = !handeler;
    }

    public void MoveDown()
    {
        if (handeler) charaSprite.sprite = walkDown1;
        else charaSprite.sprite = walkDown2;
        handeler = !handeler;
    }

    public void MoveLeft()
    {
        if (handeler) charaSprite.sprite = walkLeft1;
        else charaSprite.sprite = walkLeft2;
        handeler = !handeler;
    }

    public void MoveRight()
    {
        if (handeler) charaSprite.sprite = walkRight1;
        else charaSprite.sprite = walkRight2;
        handeler = !handeler;
    }

    public void JumpBack()
    {
        //TODO:等 Nori 接動畫
    }
}
