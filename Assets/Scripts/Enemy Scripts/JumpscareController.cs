using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public GameObject JumpscareImg;
    public Animator animator;
    public AudioSource audioSource;

    private void Start()
    {
        JumpscareImg = GameObject.Find("HUD").transform.Find("JumpscareImg").gameObject;
        animator = JumpscareImg.GetComponent<Animator>();
        JumpscareImg.SetActive(false);

        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Debug.Log("Jumpscare");
            JumpscareImg.SetActive(true);
            audioSource.Play();
            animator.SetBool("Boo", true);
            StartCoroutine(DisableJP());
        } 
    }
    IEnumerator DisableJP()
    {
        yield return new WaitForSeconds(1);
        JumpscareImg.SetActive(false);
        animator.SetBool("Boo", false);
        FindFirstObjectByType<EnemySpawner>().enemiesSpawned =- 2;
        Destroy(gameObject);
        GameObject.Find("player").GetComponent<PlayerController>().TakeDamage(1);
    }
}
