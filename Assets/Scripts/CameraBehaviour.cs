using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -5); // Keeps camera above and behind
    public float smoothSpeed = 5f;

    void LateUpdate()
    {
        if (player == null) return;

        // Get player's Y-axis rotation only
        Quaternion targetRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);

        // Calculate target position while keeping the correct height and distance
        Vector3 targetPosition = player.position + targetRotation * offset;

        // Smoothly move the camera towards the target position
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);

        // Ensure the camera looks at the player without tilting up/down
        transform.LookAt(player.position + Vector3.up * 1.5f); // Adjust height focus if needed
    }
}