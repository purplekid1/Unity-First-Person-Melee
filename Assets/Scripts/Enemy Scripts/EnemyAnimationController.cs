using UnityEngine;
using UnityEngine.AI;

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
        if (RM.Running) // Running
        {
            animator.SetBool("IsWalking", true);
            animator.SetBool("IsRunning", true);
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

