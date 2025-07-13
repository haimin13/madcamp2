using UnityEngine;

public class CameraView : MonoBehaviour
{
    private Camera cam;

    void Awake()
    {
        cam = Camera.main;
    }

    public void MoveCamera(Vector3 targetPos, ref Vector3 velocity, float smoothTime)
    {
        transform.position = Vector3.SmoothDamp(transform.position, targetPos, ref velocity, smoothTime);
    }

    public void ClampPlayerToView(Transform player)
    {
        Vector3 viewPos = cam.WorldToViewportPoint(player.position);
        viewPos.x = Mathf.Clamp(viewPos.x, 0.05f, 0.95f);
        // viewPos.y = Mathf.Clamp(viewPos.y, 0.05f, 0.95f);
        player.position = cam.ViewportToWorldPoint(viewPos);
    }
}
