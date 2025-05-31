using UnityEngine;
using System.Collections;

public class CarController : MonoBehaviour
{
    public Transform wallTarget;
    private Rigidbody rb;
    public float speed = 5f;
    public float respawnDelay = 3f;

    private Vector3 initialPosition;
    private Quaternion initialRotation;

    private bool isActive = true;
    private static int activeCarCount = 0;
    Vector3 targetPosition;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        targetPosition = new Vector3(transform.position.x, transform.position.y, wallTarget.position.z);
        if (wallTarget == null)
        {
            Debug.LogError("Wall target not assigned!");
            enabled = false;
            return;
        }

        initialPosition = transform.position;
        initialRotation = transform.rotation;
        activeCarCount++;
    }

    void Update()
    {
        if (!isActive || wallTarget == null)
            return;

        
        rb.MovePosition(targetPosition);
    }


    void OnTriggerEnter(Collider collision)
    {
        Debug.LogWarning("Hit: " + collision.gameObject.name);

        if (collision.transform == wallTarget)
        {
            Debug.LogWarning("Hit the wallTarget!");
            if (isActive)
            {
                Debug.LogWarning("Collision active");
                //StartCoroutine(DespawnAndRespawn());
            }
        }
    }
    
    



    private IEnumerator DespawnAndRespawn()
    {
        isActive = false;
        activeCarCount--;

        gameObject.SetActive(false);

        yield return new WaitForSeconds(respawnDelay);

        if (activeCarCount < 2)
        {
            transform.position = initialPosition;
            transform.rotation = initialRotation;
            gameObject.SetActive(true);
            isActive = true;
            activeCarCount++;
        }
    }
}
