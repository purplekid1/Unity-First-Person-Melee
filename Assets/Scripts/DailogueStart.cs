using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DailogueStart : MonoBehaviour
{
    [SerializeField] public GameObject dailogueCanvas;

    public PlayerController playerController;

    public DialogueTrigger dialogueTrigger;

    public DialogueManager dialogueManager;

    public Camera cam;

   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            dailogueCanvas.SetActive(true);
            
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
            dialogueTrigger.TriggerDialogue();
           


        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        dailogueCanvas.SetActive(false);
        Cursor.lockState = CursorLockMode.Locked;
        Cursor.visible = false;
        
    }

    

}
