using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting.Antlr3.Runtime.Tree;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text dialogueText;

    public Animator animator;

    public Queue<string> sentences;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();

    }

   

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        sentences.Clear();

        nameText.text = dialogue.name;

        //set the starting sentence before we can go to next sentence
        //dialogueText.text = dialogue.sentences[0];

        //sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue(sentence);
            Debug.Log("Enqueing dialouge to play... Count:"+ sentences.Count);
        }
        
        //go to the first sentence without showing last dialogue

        DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        Debug.Log("Removing sentence from queue... Count:"+ sentences.Count);
        
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    private IEnumerator TypeSentence ( string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

    private void EndDialogue()
    {
        sentences.Clear();
        animator.SetBool("isOpen", false);
    
    }

}

