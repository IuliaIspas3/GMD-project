using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    private Rigidbody rb;

    private Animator animator;
    private float movementY; // Only used for forward/backward movement
    private float rotationX; // Used for rotation
    public float speed = 5f;
    public float rotationSpeed = 100f; // Rotation speed
    public float jumpForce = 5f;
    private bool isGrounded;
    private bool doubleJump;

    void Start()
    {
        rb = GetComponent<Rigidbody>();

        // Find the Animator component in the child object
        animator = GetComponentInChildren<Animator>();

        if (animator != null)
        {
            Debug.Log("Animator found in child object!");
        }
        else
        {
            Debug.LogError("Animator not found in child object.");
        }
    }

    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        rotationX = movementVector.x; 
        movementY = movementVector.y;
    
        // Set animator to true when moving forward/backward
        if (movementY != 0) // If there is vertical movement (W or S pressed)
        {
            animator.SetBool("isWalking", true);
        }
        else
        {
            animator.SetBool("isWalking", false); // If not moving vertically, set walking to false
        }
    }

    void OnJump()
    {
        if (isGrounded)
        {
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            isGrounded = false;
            doubleJump = false;
            animator.SetBool("isJumping", true);
        }
        else if (!doubleJump)
        {
            //Quaternion rotation = Quaternion.Euler(0, rotationX * rotationSpeed * Time.fixedDeltaTime, 0);
            //rb.MoveRotation(rb.rotation * rotation);
            rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
            doubleJump = true;
            animator.SetBool("doubleJump", doubleJump);
        }
        
    }

    private void FixedUpdate(){
        Quaternion rotation = Quaternion.Euler(0, rotationX * rotationSpeed * Time.fixedDeltaTime, 0);
        rb.MoveRotation(rb.rotation * rotation);
        
        Vector3 movement = transform.forward * movementY * speed * Time.fixedDeltaTime;
        rb.MovePosition(rb.position + movement);
    }

    private void OnCollisionEnter(Collision collision)
    {
        Debug.Log("Collided with: " + collision.gameObject.name);
        if (collision.gameObject.CompareTag("Ground")) 
        {
            Debug.Log("Ground detected!");
            isGrounded = true;
            doubleJump = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("doubleJump", doubleJump);
        }
    }

}