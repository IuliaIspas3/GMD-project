using UnityEngine;

public class CharacterUnderObstacleController : MonoBehaviour
{
    private MainCharacterController playerController;
    public BoxCollider boxCollider;
    private Vector3 originalSize;
    private Vector3 originalCenter;
    public float crouchHeight = 0.5f;
    private bool playerInZone = false;

    void Start()
    {
        originalSize = boxCollider.size;
        originalCenter = boxCollider.center;
        playerController = GetComponent<MainCharacterController>();  
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("UnderObstacle"))
        {
            playerInZone = true;
            boxCollider.size = originalSize;
            boxCollider.center = originalCenter;
        }
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("UnderObstacle"))
        {
            Debug.LogWarning("Left a UnderObstacle");
            if (Input.GetKeyDown(KeyCode.B))
            {
                float heightDifference = originalSize.y - crouchHeight;
                Debug.LogWarning("crouching");

                boxCollider.size = new Vector3(originalSize.x, crouchHeight, originalSize.z);


                boxCollider.center = new Vector3(
                    originalCenter.x,
                    originalCenter.y - heightDifference / 2f,
                    originalCenter.z
                );  
            }
        }
    }


}
