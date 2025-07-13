using UnityEngine;

public class CameraController : MonoBehaviour
{
    public Transform player1;
    public Transform player2;

    private CameraModel model;
    private CameraView view;

    void Awake()
    {
        model = new CameraModel();
        view = GetComponent<CameraView>();
    }

    void LateUpdate()
    {
        if (player1 == null || player2 == null) return;

        // 두 플레이어 중심 계산
        Vector3 center = (player1.position + player2.position) / 2f;
        Vector3 newCamPos = new Vector3(center.x, center.y, transform.position.z);

        // 카메라 위치 부드럽게 이동
        view.MoveCamera(newCamPos, ref model.velocity, model.smoothTime);

        // 플레이어 위치 화면 제한
        view.ClampPlayerToView(player1);
        view.ClampPlayerToView(player2);
    }
}
