using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour
{
    public Transform character;
    private NavMeshAgent agent;
    private Animator animator;

    public float chaseRange = 15f;
    public float punchRange = 2f;

    void Start()
    {
        agent = GetComponent<NavMeshAgent>();
        animator = GetComponentInChildren<Animator>();

        if (character == null)
        {
            GameObject foundPlayer = GameObject.FindGameObjectWithTag("Character");
            if (foundPlayer != null)
                character = foundPlayer.transform;
            else
                Debug.LogError("Player not found! Make sure your player has the 'Character' tag.");
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
            }
            else
            {
                agent.SetDestination(character.position);
                animator.SetBool("isWalking", true);
                animator.SetBool("isPunching", false);
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