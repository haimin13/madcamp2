using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class GameUIController : MonoBehaviour
{
    public GameObject winText;
    public GameObject restartButton;

    public void ShowWinUI()
    {
        winText.SetActive(true);
        restartButton.SetActive(true);
    }

    public void OnRestartButtonClick()
    {
        Time.timeScale = 1f;
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
