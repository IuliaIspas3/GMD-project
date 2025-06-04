using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform character;
    private NavMeshAgent agent;
    private Animator animator;
    private AudioSource audioSource;

    public float chaseRange = 15f;
    public float punchRange = 2f;
    private bool hasPlayed = false;
    public float speed = 4f;
    
    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        audioSource = GetComponent<AudioSource>();
        agent.speed = speed;
        animator = GetComponentInChildren<Animator>();
        
        if (character == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("CharacterParent");
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
            if (!hasPlayed)
            {
                audioSource.Play();
                hasPlayed = true;
            }
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
                direction.y = 0; 
                if (direction != Vector3.zero)
                {
                    Quaternion lookRotation = Quaternion.LookRotation(direction);
                    transform.rotation = Quaternion.Slerp(transform.rotation, lookRotation, Time.deltaTime * 5f);
                }
            }
        }
        else
        {
            agent.ResetPath();
            hasPlayed = false;
            animator.SetBool("isWalking", false);
            animator.SetBool("isPunching", false);
        }
    }
}
