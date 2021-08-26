using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Jump Force")]
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float lateralForce = 5.0f;

    [Header("X-Axis Range")]
    [SerializeField] private float moveRange = 12.0f;

    private Rigidbody2D rb = null;
    private bool isGrounded = true;
    private PlayerAnimationBehaviour playerAnim = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimationBehaviour>();
    }

    public float XAxisVelocity()
    {
        return rb.velocity.x;
    }

    public float YAxisVelocity()
    {
        return rb.velocity.y;
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
        playerAnim.Jump();
    }

    public void Left()
    {
        if (transform.position.x <= -moveRange)
            return;

        rb.AddForce(new Vector2(-lateralForce, 0));
    }

    public void Right()
    {
        if (transform.position.x >= moveRange)
            return;

        rb.AddForce(new Vector2(lateralForce, 0));
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            playerAnim.Land();
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            playerAnim.Land();
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
