using UnityEngine;

public class FollowPlayer : MonoBehaviour
{
    public Transform playerCamera;  // Drag the Main Camera (inside XR Rig) here
    public Vector3 offset = new Vector3(2.0f, 0f, 3.0f); // Right and Forward

    void Update()
    {
        if (playerCamera != null)
        {
            // Offset is relative to camera's rotation
            Vector3 targetPosition = playerCamera.position + playerCamera.TransformDirection(offset);
            transform.position = Vector3.Lerp(transform.position, targetPosition, Time.deltaTime * 10f);
        }
    }
}
