using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player entered the trigger zone!");
            }
        }
    
        /*
        private void OnTriggerStay(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player is still in the trigger zone.");
            }
        }
        */
    
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player exited the trigger zone.");
            }
        }
}
