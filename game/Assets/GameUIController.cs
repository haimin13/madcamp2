using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using TMPro;

public class GameUIController : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;
    public GameObject saveRecordButton;

    void Start()
    {
        saveRecordButton.SetActive(false);
    }

    public void ShowWinUI()
    {
        saveRecordButton.SetActive(true);
        winText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void OnClickSaveRecord()
    {
        string mapId = "map1"; // 혹은 동적으로 받을 수도 있음
        float time = GameManager.Instance.GetFinalTime();
        GameManager.Instance.SendRecordToServer(mapId, time);

        saveRecordButton.SetActive(false); // 누른 후 숨기기 (선택)
    }
}
