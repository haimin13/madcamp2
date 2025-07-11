using UnityEngine;
using TMPro;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class GameManager : MonoBehaviour
{
    public static GameManager Instance;
    public string serverUrl;

    public string googleIdToken;
    public string user_name1;
    public string user_name2;

    private float startTime;
    private bool isRunning = false;
    private float currentTime = 0f;

    public TextMeshProUGUI timerText;

    // JavaScript → Unity: 로그인 후 ID Token 받음
    public void OnGoogleLogin(string idToken)
    {
        googleIdToken = idToken;
        Debug.Log("Received Google ID Token: " + idToken);
    }

    // JavaScript → Unity: 사용자 이름 2개 받음
    public void SetPlayerNames(string names)
    {
        string[] split = names.Split(',');
        if (split.Length >= 2)
        {
            user_name1 = split[0].Trim();
            user_name2 = split[1].Trim();
            Debug.Log("플레이어1: " + user_name1 + " / 플레이어2: " + user_name2);
        }
        else
        {
            Debug.LogError("사용자 이름이 부족합니다.");
        }
    }

    void Awake()
    {
        if (Instance == null)
            Instance = this;
        else
            Destroy(gameObject);
    }

    void Update()
    {
        if (isRunning)
        {
            currentTime = Time.time - startTime;
            Debug.Log("경과 시간: " + currentTime.ToString("F2") + "초");
            timerText.text = currentTime.ToString("F2");
        }
    }

    public void SetServerUrl(string url)
    {
        serverUrl = url;
        Debug.Log("Received Server");
    }

    public void StartTimer()
    {
        startTime = Time.time;
        isRunning = true;
        Debug.Log("타이머 시작");
    }

    public void StopTimer()
    {
        isRunning = false;
        Debug.Log("타이머 정지 - 최종 시간: " + currentTime.ToString("F2"));
    }

    public float GetFinalTime()
    {
        return currentTime;
    }

    [System.Serializable]
    public class RecordData
    {
        public int user_id;
        public string username1;
        public string username2;
        public int map_id;
        public float time_record;
    }

    // 예: 서버로 기록 저장 (추후 사용)
    public void SendRecordToServer(int currentMapId, float time)
    {
        RecordData data = new RecordData
        {
            user_id = 1,
            username1 = user_name1,
            username2 = user_name2,
            map_id = currentMapId,
            time_record = time
        };
        StartCoroutine(PostRequest(serverUrl, data));
    }    

    // public void SendRecordToServer(string mapId, float timeRecord)
    // {
    //     Debug.Log("서버로 전송할 정보:");
    //     Debug.Log("ID Token: " + googleIdToken);
    //     Debug.Log("Username1: " + username1);
    //     Debug.Log("Username2: " + username2);
    //     Debug.Log("Map ID: " + mapId);
    //     Debug.Log("Time Record: " + timeRecord);
    //     StartCoroutine(PostRecordCoroutine(mapId, timeRecord));
    // }

    private IEnumerator PostRequest(string url, RecordData data)
    {
        string jsonData = JsonUtility.ToJson(data);
        var request = new UnityWebRequest(url, "POST");

        byte[] bodyRaw = Encoding.UTF8.GetBytes(jsonData);
        request.uploadHandler = new UploadHandlerRaw(bodyRaw);
        request.downloadHandler = new DownloadHandlerBuffer();

        request.SetRequestHeader("Content-Type", "application/json");
        Debug.Log("서버로 전송할 데이터: " + jsonData);

        yield return request.SendWebRequest();

        if (request.result == UnityWebRequest.Result.ConnectionError || request.result == UnityWebRequest.Result.ProtocolError)
        {
            Debug.LogError("기록 전송 실패: " + request.error);
            Debug.LogError("서버 응답: " + request.downloadHandler.text);
        }
        else
        {
            Debug.Log("기록 전송 성공!");
            Debug.Log("서버 응답: " + request.downloadHandler.text);
        }

        request.Dispose();
    }    

    // private IEnumerator PostRecordCoroutine(string mapId, float timeRecord)
    // {
    //     string url = "http://127.0.0.1:3000/api/records"; // ✅ 여기를 실제 서버 URL로 바꿔줘

    //     // JSON 만들기
    //     var jsonData = new RecordData
    //     {
    //         user_id_google = googleIdToken,
    //         username1 = username1,
    //         username2 = username2,
    //         map_id = mapId,
    //         time_record = timeRecord.ToString("F2")
    //     };

    //     string json = JsonUtility.ToJson(jsonData);

    //     // UnityWebRequest 준비
    //     UnityWebRequest request = new UnityWebRequest(url, "POST");
    //     byte[] bodyRaw = System.Text.Encoding.UTF8.GetBytes(json);
    //     request.uploadHandler = new UploadHandlerRaw(bodyRaw);
    //     request.downloadHandler = new DownloadHandlerBuffer();
    //     request.SetRequestHeader("Content-Type", "application/json");

    //     Debug.Log("전송 중: " + json);

    //     yield return request.SendWebRequest();

    //     if (request.result == UnityWebRequest.Result.Success)
    //     {
    //         Debug.Log("기록 전송 성공: " + request.downloadHandler.text);
    //     }
    //     else
    //     {
    //         Debug.LogError("기록 전송 실패: " + request.error);
    //     }
    // }
}
