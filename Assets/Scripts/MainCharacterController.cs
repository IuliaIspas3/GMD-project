using System.Collections;
using System.Collections.Generic;
using UnityEditor.IMGUI.Controls;
using UnityEngine;
using UnityEngine.InputSystem;

public class MainCharacterController : MonoBehaviour
{
    private Rigidbody rb;
    private Animator animator;

    private float rotationX;
    private float movementY;
    public float rotationSpeed = 100f;
    public float speed = 5f;
    public float jumpForce = 5f;

    private bool isGrounded;
    private bool doubleJump;
    public bool sideWalk = false;
    public bool crouching;
    private Quaternion targetRotation;
    private Coroutine rotationCoroutine;
    private GameObject characterModel;

    void Start()
    {
        rb = GetComponent<Rigidbody>();
        characterModel = GameObject.FindWithTag("Character");
        rb.collisionDetectionMode = CollisionDetectionMode.Continuous;

        animator = GetComponentInChildren<Animator>();
        if (animator != null)
            Debug.Log("Animator found in child object!");
        else
            Debug.LogError("Animator not found in child object.");
    }

    void FixedUpdate()
    {
        if (sideWalk)
        {
            speed = 2f;
            Vector3 horizontalMovement = Vector3.right * movementY * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + horizontalMovement);
        }
        else
        {
            // if (crouching)
            // {
            //     animator.SetBool("isCrouchWalking", true);
            //     Debug.Log("Crouch Walking ENABLED");
            // }

            speed = 5f;
            Quaternion rotation = Quaternion.Euler(0, rotationX * rotationSpeed * Time.fixedDeltaTime, 0);
            rb.MoveRotation(rb.rotation * rotation);

            Vector3 forwardMovement = transform.forward * movementY * speed * Time.fixedDeltaTime;
            rb.MovePosition(rb.position + forwardMovement);
        }
    }
    

    void Update()
    {
        if (Keyboard.current.pKey.wasPressedThisFrame || Input.GetKeyDown(KeyCode.Joystick1Button1))
        {
            ToggleSideWalk();
        }

        if (Keyboard.current.bKey.wasPressedThisFrame || Input.GetKeyDown(KeyCode.Joystick1Button2))
        {
            ToggleCrouching();
        }

        // if (crouching)
        // {
        //     if (Keyboard.current.leftArrowKey.isPressed)
        //     {
        //         animator.SetBool("isCrouchWalking",true);
        //     }
        // }

        if (sideWalk)
        {
            if (Keyboard.current.leftArrowKey.isPressed || (Input.GetAxis("Horizontal") < -0.1f))
            {
                movementY = -1;

                animator.SetBool("isSideWalkingLeft", true);
                animator.SetBool("isSideWalkingRight", false);
            }
            else if (Keyboard.current.rightArrowKey.isPressed || (Input.GetAxis("Horizontal") > 0.1f))
            {
                movementY = 1;

                animator.SetBool("isSideWalkingLeft", false);
                animator.SetBool("isSideWalkingRight", true);
            }
            else
            {
                movementY = 0;

                animator.SetBool("isSideWalkingLeft", false);
                animator.SetBool("isSideWalkingRight", false);
            }
        }
    }


    void OnMove(InputValue movementValue)
    {
        Vector2 movementVector = movementValue.Get<Vector2>();
        rotationX = movementVector.x;
        movementY = movementVector.y;

        if (!sideWalk)
        {
            animator.SetBool("isRunning", movementY != 0);
        }
        
        if (crouching)
        {
            animator.SetBool("isCrouchWalking", movementY != 0);
            animator.SetBool("isRunning", false); 
        }
        else
        {
            animator.SetBool("isRunning", movementY != 0);
            animator.SetBool("isCrouchWalking", false); 
        }
    }

    void OnJump()
    {
        Debug.Log("Jumps");
        if (!sideWalk)
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
                rb.AddForce(Vector3.up * jumpForce, ForceMode.Impulse);
                doubleJump = true;
                animator.SetBool("isDoubleJumping", true);
            }
        }
    }

    void ToggleSideWalk()
    {
        sideWalk = !sideWalk;

        if (sideWalk)
        {
            rb.constraints = RigidbodyConstraints.FreezePositionZ | RigidbodyConstraints.FreezeRotation;
            Debug.LogWarning("Side-walking ENABLED (X-axis)");
        }
        else
        {
            rb.constraints = RigidbodyConstraints.FreezeRotation;

            // Reset both animations when sidewalk mode ends
            animator.SetBool("isSideWalkingLeft", false);
            animator.SetBool("isSideWalkingRight", false);

            Debug.Log("Side-walking DISABLED");
        }
    }

    IEnumerator SmoothRotateCharacter(Quaternion targetRotation)
    {
        float duration = 0.25f;
        float elapsed = 0f;
        Quaternion initialRotation = characterModel.transform.rotation;

        while (elapsed < duration)
        {
            characterModel.transform.rotation = Quaternion.Slerp(initialRotation, targetRotation, elapsed / duration);
            elapsed += Time.deltaTime;
            yield return null;
        }

        characterModel.transform.rotation = targetRotation;
    }


    void ToggleCrouching()
    {
        crouching = !crouching;

        animator.SetBool("isCrouching", crouching);
        animator.SetBool("isCrouchWalking", false); // reset

        if (crouching)
        {
            Debug.Log("Crouching ENABLED!");
            StartCoroutine(SmoothRotateCharacter(Quaternion.Euler(0f, 45f, 0f)));
        }
        else
        {
            Debug.Log("Crouching DISABLED!");
            StartCoroutine(SmoothRotateCharacter(Quaternion.Euler(0f, 0f, 0f)));
        }
    }



    private void OnCollisionEnter(Collision collision)
    {
        if (collision.gameObject.CompareTag("Ground"))
        {
            Debug.Log("Ground touched");
            isGrounded = true;
            doubleJump = false;
            animator.SetBool("isJumping", false);
            animator.SetBool("isDoubleJumping", false);
        }
    }
}
