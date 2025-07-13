using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerView : MonoBehaviour
{
    private Rigidbody2D rb;
    private Animator animator;
    private SpriteRenderer spriteRenderer;

    void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public float GetVerticalVelocity()
    {
        return rb.linearVelocity.y;
    }

    public void UpdateAnimation(float moveInput, bool isGrounded, float verticalVelocity)
    {
        if (moveInput > 0.01f)
        {
            spriteRenderer.flipX = false;
        }
        else if (moveInput < -0.01f)
        {
            spriteRenderer.flipX = true;
        }

        if (!isGrounded)
        {
            if (verticalVelocity > 0.01f)
            {
                animator.SetInteger("PlayerState", 1);
            }
            else if (verticalVelocity < -0.01f)
            {
                animator.SetInteger("PlayerState", 2);
            }
        }
        else if (Mathf.Abs(moveInput) > 0.01f)
        {
            animator.SetInteger("PlayerState", 3);
        }
        else
        {
            animator.SetInteger("PlayerState", 0);
        }
    }

    public void Move(float direction, float speed)
    {
        rb.linearVelocity = new Vector2(direction * speed, rb.linearVelocity.y);
    }

    public void Jump(float force)
    {
        rb.linearVelocity = new Vector2(rb.linearVelocity.x, force);
    }

    public void StopGame()
    {
        Time.timeScale = 0f;
    }

    public void ResumeGame()
    {
        Time.timeScale = 1f;
    }
}