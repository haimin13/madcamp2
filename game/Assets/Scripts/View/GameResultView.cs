using UnityEngine;

public class GameResultView : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;
    public GameObject saveRecordButton;

    public void ShowResultUI()
    {
        winText.SetActive(true);
        restartButton.SetActive(true);
        saveRecordButton.SetActive(true);
    }

    public void HideSaveButton()
    {
        saveRecordButton.SetActive(false);
    }

    void Start()
    {
        HideSaveButton();
    }
}