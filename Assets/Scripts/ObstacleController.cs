using System;
using UnityEngine;

public class ObstacleController : MonoBehaviour
{
   
    private void OnTriggerEnter(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player entered the trigger zone!");
                if (transform.gameObject.CompareTag("tightObstacle")) 
                {
                    GameManager.SetMessage("Press RED button to side walk.", Color.red);
                }
                else if (transform.gameObject.CompareTag("UnderObstacle"))
                {
                    Debug.LogWarning("UnderObstacle");
                    GameManager.SetMessage("Press BLUE button to crouch.", Color.blue);
                }
                else if (transform.gameObject.CompareTag("lampCollider"))
                {
                    Debug.LogWarning("Lamp control");
                    GameManager.SetMessage("Press YELLOW button to jump on the lamp.", Color.yellow);
                }
            }
        }
    
        private void OnTriggerExit(Collider other)
        {
            if (other.CompareTag("Character"))
            {
                Debug.Log("Player exited the trigger zone.");
                GameManager.ClearMessage();
            }
        }
}
