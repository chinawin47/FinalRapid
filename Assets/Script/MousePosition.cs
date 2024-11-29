using UnityEngine;

public class CameraPanFollowMouse : MonoBehaviour
{
    [Header("Pan Settings")]
    public float panSpeed = 5f; // How quickly the camera moves
    public Vector2 panOffset = Vector2.zero; // Offset to adjust the camera position

    private Vector3 startPosition;

    void Start()
    {
        // Store the camera's initial position
        startPosition = transform.position;
    }

    void Update()
    {
        // Get mouse position in world space
        Vector3 mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

        // Calculate the target position based on mouse movement and offset
        Vector3 targetPosition = startPosition + (mousePosition - startPosition) + (Vector3)panOffset;

        // Keep the z-axis constant (for 2D)
        targetPosition.z = transform.position.z;

        // Smoothly move the camera
        transform.position = Vector3.Lerp(transform.position, targetPosition, panSpeed * Time.deltaTime);
    }
}
