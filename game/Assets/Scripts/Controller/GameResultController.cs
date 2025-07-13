using UnityEngine;
using UnityEngine.SceneManagement;

public class GameResultController : MonoBehaviour
{
    public GameResultView view;
    public GameController gameController; // 기존 GameController (타이머, 기록 관리 등)

    public void OnPlayerWin()
    {
        view.ShowResultUI();
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene("GameScene");
    }

    public void OnClickSaveRecord()
    {
        float finalTime = gameController.GetFinalTime();
        int mapId = gameController.mapId;

        gameController.SendRecordToServer(mapId, finalTime);
        view.HideSaveButton();
    }
}

