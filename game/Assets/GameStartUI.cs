using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartUI : MonoBehaviour
{
    public PlayerMovement playerMovement;      // 플레이어 이동 스크립트

    void Start()
    {
        playerMovement.enabled = true;
    }
}
