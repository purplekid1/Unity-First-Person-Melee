using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;

public class jumpscareController : MonoBehaviour
{
    public GameObject jumpscare;
    public EnemyManager enemyManager;
    public Animator animator;
    private Vector3 position;
    public GameObject JP;


    private void Start()
    {

        jumpscare.SetActive(false);
        enemyManager = GameObject.Find("Monster").GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {
        position = jumpscare.transform.position;

        position.y = JP.transform.position.y;
        position.x = JP.transform.position.x;
        if (enemyManager.jumpscare)
        {
            jumpscare.SetActive(true);
            animator.SetBool("jumpscare", true);
        }
    }
}
