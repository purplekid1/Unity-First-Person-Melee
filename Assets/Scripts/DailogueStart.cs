using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Windows;

public class DailogueStart : MonoBehaviour
{
    [SerializeField] public GameObject dailogueCanvas;


    public DialogueTrigger dialogueTrigger;

    public DialogueManager dialogueManager;


   

    private void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == ("Player"))
        {
            dailogueCanvas.SetActive(true);
            
            
            dialogueTrigger.TriggerDialogue();
           


        }
    }

    

    private void OnTriggerExit(Collider other)
    {
        dailogueCanvas.SetActive(false);

        dialogueManager.scentenceTracker = 0;
    }

    

}
