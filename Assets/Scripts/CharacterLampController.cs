using System.Collections;
using UnityEngine;
using UnityEngine.InputSystem;

public class CharacterLampController : MonoBehaviour
{
    private BoxCollider boxCollider;
    private Rigidbody rb;
    private bool canClimb = false;
    private Transform lampTransform;
    private bool isClimbing = false;

    public float climbDuration = 1.0f; 

    void Start()
    {
        boxCollider = transform.GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        if (canClimb && !isClimbing && Keyboard.current.lKey.wasPressedThisFrame)
        {
            StartCoroutine(MoveToTopOfLamp());
        }
    }

    private IEnumerator MoveToTopOfLamp()
    {
        isClimbing = true;

        Bounds bounds = lampTransform.GetComponent<Collider>().bounds;
        Vector3 targetPosition = new Vector3(
            bounds.center.x,
            bounds.max.y + 0.5f, // offset above lamp
            bounds.center.z
        );

        Vector3 startPosition = rb.position;
        float elapsed = 0f;

        while (elapsed < climbDuration)
        {
            rb.MovePosition(Vector3.Lerp(startPosition, targetPosition, elapsed / climbDuration));
            elapsed += Time.deltaTime;
            yield return null;
        }

        rb.MovePosition(targetPosition); 
        isClimbing = false;
    }

    private void OnTriggerStay(Collider other)
    {
        if (other.CompareTag("lampCollider"))
        {
            canClimb = true;
            Debug.LogWarning("LampCollider");
            lampTransform = other.transform;
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("lampCollider"))
        {
            canClimb = false;
            lampTransform = null;
            Debug.LogWarning("Left a lamp collider");
        }
    }
}
