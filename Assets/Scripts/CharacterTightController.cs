using System;
using UnityEngine;

public class CharacterTightController : MonoBehaviour
{
    private bool playerInZone;
    private BoxCollider boxCollider;
    private Vector3 ogSize;
    private Rigidbody rb;


    private void Start()
    {
        boxCollider = GetComponent<BoxCollider>();
        rb = GetComponent<Rigidbody>();
        ogSize = boxCollider.size;
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("tightObstacle"))
        {
            playerInZone = true;
            Vector3 newSize = ogSize; 
            newSize.x = ogSize.x * 2f;
            boxCollider.size = newSize;
            Debug.LogWarning("Player entered tight zone");
        }
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("tightObstacle"))
        {
            playerInZone = false;
            boxCollider.size = ogSize;
            Debug.LogWarning("Player exited tight zone");
        }
    }

    private void Update()
    {
        if (playerInZone)
        {
            if (Input.GetKeyDown(KeyCode.P) || Input.GetKeyDown(KeyCode.Joystick1Button1))
            {
                Debug.LogWarning("P down");
                boxCollider.size = ogSize;
                transform.eulerAngles = new Vector3(transform.eulerAngles.x, 360f, transform.eulerAngles.z);

            }
        }
    }
    
  

}