using UnityEngine;
using UnityEngine.AI;
<<<<<<< HEAD
=======
using UnityEngine.InputSystem;
>>>>>>> e02c994376d1dab36ba9ed513b621011ce15a006

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
<<<<<<< HEAD
        if (agent.acceleration >= 0.01f && agent.acceleration !>= 10f && agent.remainingDistance > agent.stoppingDistance) // Moving
=======
        if (RM.Running) // Running
>>>>>>> e0aebd014b8bfbc935b46bc5d205efdaf225d79f
        {
            animator.SetBool("IsWalking", true);
<<<<<<< HEAD
            animator.SetBool("IsRunning", true);
=======
            //animator.SetBool("IsRunning", false);
>>>>>>> e02c994376d1dab36ba9ed513b621011ce15a006
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

