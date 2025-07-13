using UnityEngine;

public class GameController : MonoBehaviour
{
    public GameModel model;
    public GameView view;

    [Header("Game Settings")]
    public int mapId = 1;  // 맵 ID는 수동 또는 설정 파일에서 불러올 수 있음
    public RecordSender recordSender;
    
    void Awake()
    {
        model = new GameModel(); // 생성자 호출
    }
    void Update()
    {
        if (model.IsTimerRunning())
        {
            float currentTime = model.UpdateAndGetCurrentTime();
            view.UpdateTimerText(currentTime);
        }
    }

    public void OnGoogleLogin(string idToken)
    {
        model.SetIdToken(idToken);
        Debug.Log("Google ID Token 저장됨: " + idToken);
    }

    public void SetPlayerNames(string names)
    {
        string[] split = names.Split(',');
        if (split.Length >= 2)
        {
            model.SetPlayerNames(split[0], split[1]);
            Debug.Log("사용자 이름 저장됨: " + split[0] + ", " + split[1]);
        }
        else
        {
            Debug.LogError("사용자 이름이 부족합니다.");
        }
    }

    public void StartTimer()
    {
        model.StartTimer();
        Debug.Log("타이머 시작");
    }

    public void FinishGame()
    {
        model.StopTimer();
        float finalTime = model.GetFinalTime();
        Debug.Log("타이머 정지 - 기록: " + finalTime.ToString("F2"));
    }

    public void SetServerUrl(string url)
    {
        recordSender.SetServerUrl(url);
        Debug.Log("서버 주소 설정 완료: " + url);
    }

    public float GetFinalTime()
    {
        return model.GetFinalTime();
    }

    public void SendRecordToServer(int mapId, float finalTime)
    {
        recordSender.SendRecord(
            userId: 1,  // 임시값, 실제로는 서버에서 ID 조회 필요
            username1: model.Username1,
            username2: model.Username2,
            mapId: mapId,
            timeRecord: finalTime
        );
    }


}
