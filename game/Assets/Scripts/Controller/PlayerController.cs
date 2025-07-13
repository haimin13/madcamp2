using UnityEngine;

public class PlayerController : MonoBehaviour
{
    public PlayerModel.PlayerType playerType;
    public LayerMask groundLayer;
    public Transform groundCheck;
    public float raycastLength = 0.2f;

    private PlayerModel model;
    private PlayerView view;

    private bool isGrounded = false;
    private bool jumpPressed = false;
    private float moveInput = 0f;

    private GameController gameController;
    private GameResultController gameResultController;

    private void Start()
    {
        gameController = FindFirstObjectByType<GameController>();
        gameResultController = FindFirstObjectByType<GameResultController>();
    }

    void Awake()
    {
        model = new PlayerModel(playerType);
        view = GetComponent<PlayerView>();
    }

    void Update()
    {
        // 바닥 체크
        if (groundCheck != null)
        {
            RaycastHit2D hit = Physics2D.Raycast(groundCheck.position, Vector2.down, raycastLength, groundLayer);
            isGrounded = hit.collider != null;
        }

        // 입력 처리
        if (playerType == PlayerModel.PlayerType.Player1)
        {
            moveInput = Input.GetAxisRaw("Horizontal_P1");
            if (Input.GetButtonDown("Jump_P1") && isGrounded && model.CanJump())
                jumpPressed = true;
            view.UpdateAnimation(moveInput, isGrounded, view.GetVerticalVelocity());
        }
        else if (playerType == PlayerModel.PlayerType.Player2)
        {
            moveInput = Input.GetAxisRaw("Horizontal_P2");
            if (Input.GetButtonDown("Jump_P2") && isGrounded && model.CanJump())
                jumpPressed = true;
            view.UpdateAnimation(moveInput, isGrounded, view.GetVerticalVelocity());
        }

        // 타이머 시작
        if (!model.hasStarted && (Mathf.Abs(moveInput) > 0.01f || jumpPressed))
        {
            gameController.StartTimer();
            model.hasStarted = true;
        }
    }

    void FixedUpdate()
    {
        view.Move(moveInput, model.moveSpeed);

        if (jumpPressed)
        {
            view.Jump(model.jumpForce);
            model.RecordJumpTime();
            jumpPressed = false;
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.CompareTag("Obstacle"))
        {
            Debug.Log("Game Over");
            view.StopGame();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.CompareTag("Finish"))
        {
            Debug.Log("You Win!");
            view.StopGame();

            gameController.FinishGame();
            gameResultController.OnPlayerWin();
        }
    }
}

