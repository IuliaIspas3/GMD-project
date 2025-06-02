using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform character;
    private NavMeshAgent agent;
    private Animator animator;

    public float chaseRange = 15f;
    public float punchRange = 2f;
    public float speed = 4f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        agent.speed = speed;
        animator = GetComponentInChildren<Animator>();
        
        if (character == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Character");
            if (foundPlayer != null)
            {
                character = foundPlayer.transform;
            }
            else
            {
                Debug.LogError("Player not found! Make sure your player has the 'Character' tag.");
            }
        }
    }

    void Update()
    {
        if (character == null) return;

        float distance = Vector3.Distance(transform.position, character.position);

        if (distance <= chaseRange)
        {
            if (distance <= punchRange)
            {
                agent.ResetPath(); 
                animator.SetBool("isWalking", false);
                animator.SetBool("isPunching", true);
                Vector3 lookDirection = character.position - transform.position;
                lookDirection.y = 0;
                if (lookDirection != Vector3.zero)
                {
                    Quaternion targetRotation = Quaternion.LookRotation(lookDirection) * Quaternion.Euler(0, 80f, 0);
                    transform.rotation = Quaternion.Slerp(transform.rotation, targetRotation, Time.deltaTime * 5f);
                }
            }
            else
            {
                agent.SetDestination(character.position);
                animator.SetBool("isWalking", true);
                animator.SetBool("isPunching", false);

                Vector3 direction = (character.position - transform.position).normalized;
                direction.y = 0; // Keep only horizontal rotation
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f); // Smooth rotation
                }
            }
        }
        else
        {
            agent.ResetPath();
            animator.SetBool("isWalking", false);
            animator.SetBool("isPunching", false);
        }
    }
}
