﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickObj : MonoBehaviour
{
    [SerializeField] private Sprite[] sprites = null;

    private Brick type = Brick.basic;
    private SpriteRenderer rend = null;

    private void Start()
    {
        rend = GetComponentInChildren<SpriteRenderer>();
    }

    public void SwapToRandomBrick()
    {
        type = (Brick)Random.Range(0, System.Enum.GetValues(typeof(Brick)).Length);

        UpdateSprite();
    }

    private void UpdateSprite()
    {
        rend.sprite = sprites[(int)type];

        if (Random.Range(0, 100) > 50)
        {
            rend.flipX = true;
        }
    }
}