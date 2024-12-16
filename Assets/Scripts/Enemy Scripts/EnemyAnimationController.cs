using UnityEngine;
using UnityEngine.AI;
using UnityEngine.InputSystem.Android;

public class EnemyAnimationController : MonoBehaviour
{
    private Animator animator;
    private NavMeshAgent agent;

    private void Start()
    {
        animator = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
    }

    private void Update()
    {
        // Check the velocity of the NavMeshAgent
        if (agent.speed >= 0.01f && agent.speed !>= 10f && agent.remainingDistance > agent.stoppingDistance) // Moving
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", false);
        }
        else if (agent.speed >= 10f && agent.remainingDistance > agent.stoppingDistance)// Idle
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true) ;
        }
    }
}

