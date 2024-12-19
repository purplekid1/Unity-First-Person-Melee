using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public GameObject JumpscareImg;
    public AudioSource audioSource;

    private void Start()
    {
        JumpscareImg = GameObject.Find("HUD").transform.Find("JumpscareImg").gameObject;
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
            StartCoroutine(DisableJP());
        } 
    }
    IEnumerator DisableJP()
    {
        yield return new WaitForSeconds(1);
        JumpscareImg.SetActive(false);
    }
}
