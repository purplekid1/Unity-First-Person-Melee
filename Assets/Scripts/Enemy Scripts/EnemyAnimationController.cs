using UnityEngine;
using UnityEngine.AI;

using UnityEngine.InputSystem;


public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;
    public RandomMovement RM; 

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
        RM = GetComponent<RandomMovement>();
    }

    private void Update()
    {
        

        // Check the velocity of the NavMeshAgent

        if (agent.velocity.sqrMagnitude >= 0.01f && agent.remainingDistance > agent.stoppingDistance) // Moving
        {
            animator.SetBool("IsWalking", true);
        }
        else // Idle
        {
            animator.SetBool("IsWalking", false);
        }
    }
}

