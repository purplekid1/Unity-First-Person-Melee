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
        if (RM.Running) // Running
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

