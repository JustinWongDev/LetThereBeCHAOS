using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAnimationBehaviour : MonoBehaviour
{
    [SerializeField] private float xAxisRunThreshold = 0.01f;

    private float xValue = 0;

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
        xValue = player.XAxisVelocity();

        Face();

        Run();
        Fall();
    }

    void Face()
    {
        if (xValue > 0)
            sprite.flipX = false;
        else if (xValue < 0)
        {
            sprite.flipX = true;
        }
    }

    private void Run()
    {
        if (Mathf.Abs(xValue) >= xAxisRunThreshold && player.IsGrounded())
        {
            anim.SetBool("isRunning", true);

        }
        else
        {
            anim.SetBool("isRunning", false);
        }
    }

    public void Jump()
    {
        anim.SetTrigger("isJumping");
    }

    public void Land()
    {
        anim.SetTrigger("isGrounded");
    }

    public void Fall()
    {
        if (player.YAxisVelocity() < -10f)
        {
            anim.SetTrigger("isFalling");
        }
        else
        {
            anim.ResetTrigger("isFalling");
        }
    }
}
