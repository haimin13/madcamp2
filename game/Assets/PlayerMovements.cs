using UnityEngine;

public class PlayerMovement : MonoBehaviour
{
    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    private Rigidbody2D rb;
    private bool isGrounded;
    private bool hasStarted = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        float h = Input.GetAxis("Horizontal");
        rb.linearVelocity = new Vector2(h * moveSpeed, rb.linearVelocity.y);

        if (!hasStarted && (Mathf.Abs(h) > 0.01f || Input.GetButtonDown("Jump")))
        {
            GameManager.Instance.StartTimer();
            hasStarted = true;
        }

        if (Input.GetButtonDown("Jump") && isGrounded)
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, jumpForce);
            isGrounded = false;
        }
    }

    void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Ground"))
        {
            isGrounded = true;
        }

        if (other.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            Time.timeScale = 0; // 게임 정지
        }

    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win!");
            Time.timeScale = 0;

            GameManager.Instance.StopTimer();

            GameObject.Find("UIManager").GetComponent<GameUIController>().ShowWinUI();
        }
    }

}
