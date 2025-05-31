using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterObstacleScript : MonoBehaviour
{
    public BoxCollider boxCollider;
    private Vector3 originalSize;
    private Vector3 originalCenter;
    public float crouchHeight = 0.5f;

    void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        originalSize = boxCollider.size;
        originalCenter = boxCollider.center;
    }

    void Update()
    {
        if (Keyboard.current.bKey.isPressed)
        {
            float heightDifference = originalSize.y - crouchHeight;

            boxCollider.size = new Vector3(
                originalSize.x,
                crouchHeight,
                originalSize.z
            );

            boxCollider.center = new Vector3(
                originalCenter.x,
                originalCenter.y - (heightDifference / 2f),
                originalCenter.z
            );
        }
        else
        {
            boxCollider.size = originalSize;
            boxCollider.center = originalCenter;
        }
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("UnderObstacle"))
        {
            Debug.LogWarning("Entered under an obstacle.");
        }

        if (other.CompareTag("tightObstacle"))
        {
            Debug.LogWarning("Entered a tight gap");
        }
        if (other.CompareTag("lampCollider"))
        {
            Debug.LogWarning("Entered a lamp collider");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnderObstacle"))
        {
            Debug.LogWarning("Left the zone");
        }
        if (other.CompareTag("tightObstacle"))
        {
            Debug.LogWarning("Left a tight gap");
        }
        if (other.CompareTag("lampCollider"))
        {
            Debug.LogWarning("Left a lamp collider");
        }
    }
}
