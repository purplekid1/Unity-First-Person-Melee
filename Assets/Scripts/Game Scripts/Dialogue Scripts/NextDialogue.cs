using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NextDialogue : MonoBehaviour
{
    //public DialogueTrigger dialogueTrigger;
    public DialogueManager dialogueManager;
    void Start()
    {
        if (dialogueManager == null)
        {
            dialogueManager = FindAnyObjectByType<DialogueManager>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Z))
        {
            dialogueManager.DisplayNextSentence();
            //dialogueTrigger.TriggerDialogue();
        }
    }
}
