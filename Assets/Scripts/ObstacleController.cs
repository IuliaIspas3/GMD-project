using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player entered the trigger zone!");
                if (transform.gameObject.CompareTag("tightObstacle")) ;
                {
                    
                }
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player exited the trigger zone.");
            }
        }
}
