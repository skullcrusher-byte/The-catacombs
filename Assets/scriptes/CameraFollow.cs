using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public float smoothSpeed = 5f;

    [Header("Room Boundaries")]
    public Vector2 minBounds;
    public Vector2 maxBounds;

    private Camera cam;

    void Start()
    {
        cam = GetComponent<Camera>();
    }

    void LateUpdate()
    {
        if (player == null) return;

        float cameraHeight = cam.orthographicSize;
        float cameraWidth = cameraHeight * cam.aspect;

        float x = Mathf.Clamp(
            player.position.x,
            minBounds.x + cameraWidth,
            maxBounds.x - cameraWidth
        );

        float y = Mathf.Clamp(
            player.position.y,
            minBounds.y + cameraHeight,
            maxBounds.y - cameraHeight
        );

        Vector3 targetPosition = new Vector3(x, y, -10f);

        transform.position = Vector3.Lerp(
            transform.position,
            targetPosition,
            smoothSpeed * Time.deltaTime
        );
    }
}