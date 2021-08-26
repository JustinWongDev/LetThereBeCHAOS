using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    [SerializeField] private float xAxisRunThreshold = 0.01f;

    PlayerController player = null;
    Animator anim = null;
    SpriteRenderer sprite = null;

    private void Start()
    {
        player = FindObjectOfType<PlayerController>();
        anim = GetComponentInChildren<Animator>();
        sprite = GetComponentInChildren<SpriteRenderer>();
    }

    private void Update()
    {
        float xValue = player.XAxisVelocity();

        if (Mathf.Abs(xValue) >= xAxisRunThreshold)
        {
            anim.SetBool("isRunning", true);

            if (xValue > 0)
                sprite.flipX = false;
            else if (xValue < 0)
            {
                sprite.flipX = true;
            }
        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }
}
