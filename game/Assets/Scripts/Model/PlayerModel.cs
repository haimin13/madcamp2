using UnityEngine;

public class PlayerModel
{
    public enum PlayerType { Player1, Player2 }
    public PlayerType playerType;

    public float moveSpeed = 5f;
    public float jumpForce = 7f;
    public bool hasStarted = false;

    public float jumpCooldown = 0.1f;
    public float lastJumpTime = -1f;

    public PlayerModel(PlayerType type)
    {
        playerType = type;
    }

    public bool CanJump()
    {
        return UnityEngine.Time.time - lastJumpTime >= jumpCooldown;
    }

    public void RecordJumpTime()
    {
        lastJumpTime = UnityEngine.Time.time;
    }
}

