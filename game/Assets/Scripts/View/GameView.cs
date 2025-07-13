using UnityEngine;
using TMPro;

public class GameView : MonoBehaviour
{
    [Header("UI Elements")]
    public TextMeshProUGUI timerText;

    public void UpdateTimerText(float time)
    {
        if (timerText != null)
        {
            timerText.text = time.ToString("F2");
        }
    }
}
