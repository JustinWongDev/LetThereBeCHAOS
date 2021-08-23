using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Jump Force")]
    [SerializeField] private float jumpForce = 10.0f;
    [SerializeField] private float lateralForce = 5.0f;

    private Rigidbody2D rb = null;
    private bool isGrounded = true;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    public void Jump()
    {
        rb.AddForce(new Vector2(0, jumpForce));
    }

    public void Left()
    {
        rb.AddForce(new Vector2(-lateralForce, 0));
    }

    public void Right()
    {
        rb.AddForce(new Vector2(lateralForce, 0));
    }

    public bool IsGrounded()
    {
        return isGrounded;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = true;
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
            isGrounded = false;
    }
}
