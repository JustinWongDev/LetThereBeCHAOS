using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickObj : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = null;
    [SerializeField] private SpriteRenderer rend = null;
    [SerializeField] private ChaosShader shad = null;

    private Brick currenType = Brick.basic;
    private Brick nextType = Brick.basic;

    public void SwapToRandomBrick()
    {
        nextType = (Brick)Random.Range(0, System.Enum.GetValues(typeof(Brick)).Length);

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        //if (nextType != currenType)
        //    StartCoroutine(shad.Shift());

        rend.sprite = sprites[(int)nextType];

        if (Random.Range(0, 100) > 50)
        {
            rend.flipX = true;
        }

        currenType = nextType;
    }
}
