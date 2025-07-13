using UnityEngine;

public class GameModel
{
    public string GoogleIdToken { get; private set; }
    public string Username1 { get; private set; }
    public string Username2 { get; private set; }

    private float startTime;
    private float currentTime;
    private bool isRunning = false;
    private bool hasStarted = false;



    public void SetIdToken(string token) => GoogleIdToken = token;

    public void SetPlayerNames(string name1, string name2)
    {
        Username1 = name1.Trim();
        Username2 = name2.Trim();
    }

    public void StartTimer()
    {
        if (hasStarted) return;
        hasStarted = true;
        startTime = UnityEngine.Time.time;
        isRunning = true;
    }

    public void StopTimer()
    {
        isRunning = false;
    }

    public bool IsTimerRunning() => isRunning;

    public float UpdateAndGetCurrentTime()
    {
        if (isRunning)
        {
            currentTime = UnityEngine.Time.time - startTime;
        }
        return currentTime;
    }

    public float GetFinalTime() => currentTime;
}