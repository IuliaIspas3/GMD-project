using System;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform player;
    public Vector3 offset = new Vector3(0, 3, -5); // Keeps camera above and behind
    public float smoothSpeed = 5f;
    private MainCharacterController controllerScript;

    private void Start()
    {
        controllerScript = player.GetComponent<MainCharacterController>();
    }

    void LateUpdate()
    {
        if (player == null) return;
        Quaternion targetRotation = Quaternion.Euler(0, player.eulerAngles.y, 0);
        Vector3 targetPosition = player.position + targetRotation * offset;
        transform.position = Vector3.Lerp(transform.position, targetPosition, smoothSpeed * Time.deltaTime);
        transform.LookAt(player.position + Vector3.up * 1.5f);
    }
}