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

    public Queue<string> useSentences;

    public int scentenceTracker;

    // Start is called before the first frame update
    void Start()
    {
        sentences = new Queue<string>();
        
        useSentences = new Queue<string>();
    }

   

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);

        useSentences.Clear();

        nameText.text = dialogue.name;

            //sentences.Clear();

            foreach (string sentence in dialogue.sentences)
            {
               
                sentences.Enqueue(sentence);
            }

            DisplayNextSentence();
        
    }

    public void DisplayNextSentence()
    {

        if (sentences.Count == useSentences.Count)
        {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        useSentences.Enqueue(sentence);
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));

    }

    IEnumerator TypeSentence ( string sentence)
    {
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return null;
        }
    }

        void EndDialogue()
        {
         animator.SetBool("isOpen", false);
        
        }

}

