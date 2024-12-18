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


    private void Start()
    {

        jumpscare.SetActive(false);
        enemyManager = GameObject.Find("Monster").GetComponent<EnemyManager>();
        animator = GetComponent<Animator>();
    }

    private void Update()
    {

    }
}
