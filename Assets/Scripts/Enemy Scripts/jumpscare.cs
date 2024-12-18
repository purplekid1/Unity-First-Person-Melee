using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class jumpscare : MonoBehaviour
{
    public GameObject Jumpscare;
    public AudioSource audioSource;

    private void Start()
    {
        Jumpscare.SetActive(false);
        Jumpscare = GameObject.Find("Jumpscare");
        audioSource = GameObject.Find("Player").GetComponent<AudioSource>();
    }

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "Player")
        {
            Jumpscare.SetActive(true);
            audioSource.Play();
            StartCoroutine(DisableJP());
        } 
    }
    IEnumerator DisableJP()
    {
        yield return new WaitForSeconds(1);
        Jumpscare.SetActive(false);
    }
}
