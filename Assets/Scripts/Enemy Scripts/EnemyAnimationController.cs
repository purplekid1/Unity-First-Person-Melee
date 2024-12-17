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

        if (agent.acceleration >= 0.01f && agent.acceleration !>= 10f && agent.remainingDistance > agent.stoppingDistance) // Moving

        if (RM.Running) // Running

        {
            animator.SetBool("IsWalking", true);

            animator.SetBool("IsRunning", true);

            //animator.SetBool("IsRunning", false);

        }
        else if (RM.Walking)// Walking
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsRunning", true) ;
        }
        else // Idle
        {
            animator.SetBool("IsWalking", false);
            animator.SetBool("IsWalking", false);
        }
    }
}

