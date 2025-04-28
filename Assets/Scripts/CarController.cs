using UnityEngine;

public class CarController : MonoBehaviour
{
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    public string wallName = "North";
        public float speed = 5f;
        private Transform target;
    
        void Start()
        {
            // Find the "North" wall under "invisibleWalls"
            GameObject wallParent = GameObject.Find("invisibleWalls");
            if (wallParent != null)
            {
                Transform wall = wallParent.transform.Find(wallName);
                if (wall != null)
                {
                    target = wall;
                }
                else
                {
                    Debug.LogWarning($"Child '{wallName}' not found under 'invisibleWalls'.");
                }
            }
            else
            {
                Debug.LogWarning("'invisibleWalls' GameObject not found in the scene.");
            }
        }
    
        void Update()
        {
            if (target != null)
            {
                // Keep the current X and Y positions, only move in Z direction
                Vector3 targetPosition = new Vector3(transform.position.x, transform.position.y, target.position.z);
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
            }
        }


    }

