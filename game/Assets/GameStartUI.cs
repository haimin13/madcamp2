using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class GameStartUI : MonoBehaviour
{
    public GameObject startPanel;              // StartPanel 전체
    public TMP_InputField nameInput;           // 이름 입력 필드
    public PlayerMovement playerMovement;      // 플레이어 이동 스크립트

    void Start()
    {
        // 시작 시 UI는 보이게 하고, 플레이어는 못 움직이게
        startPanel.SetActive(true);
        playerMovement.enabled = false;
    }

    public void OnClickStartButton()
    {
        string playerName = nameInput.text;
        Debug.Log("플레이어 이름: " + playerName);

        startPanel.SetActive(false);           // UI 숨기기
        playerMovement.enabled = true;         // 플레이어 이동 허용
    }
}
