using UnityEngine;
using UnityEngine.Networking;
using System.Collections;
using System.Text;

public class RecordSender : MonoBehaviour
{
    private string serverUrl;

    [System.Serializable]
    private class RecordData
    {
        public int user_id;
        public string username1;
        public string username2;
        public int map_id;
        public float time_record;
    }

    public void SetServerUrl(string url)
    {
        serverUrl = url;
        Debug.Log("서버 주소 설정 완료: " + url);
    }

    public void SendRecord(int userId, string username1, string username2, int mapId, float timeRecord)
    {
        RecordData data = new RecordData
        {
            user_id = userId,
            username1 = username1,
            username2 = username2,
            map_id = mapId,
            time_record = timeRecord
        };

        StartCoroutine(PostRequest(serverUrl, data));
    }

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

        request.certificateHandler.Dispose();
        request.Dispose();
    } 
}
