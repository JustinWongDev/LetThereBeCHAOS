using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{
    [Header("Var")]
    [SerializeField] private int health = 3;
    [SerializeField] private float fallToDeathTime = 3;
    private float fallToDeathTimer = 0.0f;
    private bool fellToDeath = false;

    [Header("Jump Force")]
    [SerializeField] public float jumpForce = 10.0f;
    [SerializeField] private float lateralForce = 5.0f;

    [Header("X-Axis Range")]
    [SerializeField] private float moveRange = 12.0f;

    [Header("VFX")]
    [SerializeField] private GameObject damageVFX = null;

    private Rigidbody2D rb = null;
    private bool isGrounded = true;
    private PlayerAnimationBehaviour playerAnim = null;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        playerAnim = GetComponent<PlayerAnimationBehaviour>();

        GameManager.Instance.Newgame.AddListener(NewGame);
    }

    private void Update()
    {
        if (!isGrounded)
        {
            fallToDeathTimer -= Time.deltaTime;

            if (fallToDeathTimer <= 0)
            {
                fellToDeath = true;
            }
        }
    }

    private void NewGame()
    {
        damageVFX.SetActive(false);
        health = 3;
        fellToDeath = false;
        fallToDeathTimer = fallToDeathTime;
        transform.position = new Vector2(0, 2);
    }

    public void TakeDamage()
    {
        health--;
        damageVFX.SetActive(false);
        damageVFX.SetActive(true);

        if (health <= 0)
        {
            GameManager.Instance.Gameover?.Invoke();
        }
    }

    public void FallToDeath()
    {
        damageVFX.SetActive(false);
        damageVFX.SetActive(true);
        GameManager.Instance.Gameover?.Invoke();
    }

    public float XAxisVelocity()
    {
        return rb.velocity.x;
    }

    public float YAxisVelocity()
    {
        return rb.velocity.y;
    }

    public void Jump(float force)
    {
        rb.AddForce(new Vector2(0, force));
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

            if (fellToDeath)
            {
                FallToDeath();
            }
        }
    }

    private void OnCollisionStay2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = true;
            playerAnim.Land();

            if (fellToDeath)
            {
                FallToDeath();
            }
        }

    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.tag == "Ground")
        {
            isGrounded = false;
            fallToDeathTimer = fallToDeathTime;
        }

    }
}
