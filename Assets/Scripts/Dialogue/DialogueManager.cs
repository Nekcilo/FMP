using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class DialogueManager : MonoBehaviour
{
  public TextMeshProUGUI dialogueText;
  public Animator animator;

    private Queue<string> sentences;
    bool started = false;

    // Start is called before the first frame update
    void Start()
    {
      sentences = new Queue<string>();  
    }

    public void StartDialogue (Dialogue dialogue)
    {
      if(!started)
      {
        animator.SetBool("IsOpen", true);
        
        Debug.Log("Starting Conversation...");

        sentences.Clear();

        foreach (string sentence in dialogue.sentences)
        {
          sentences.Enqueue(sentence);
        }

        started = true;
        DisplayNextSentence();
      }
      else
      {
        DisplayNextSentence();
      }

    }

    public void DisplayNextSentence()
    {
      if (sentences.Count == 0)
      {
        EndDialogue();
        return;
      }
      string sentence = sentences.Dequeue();
      dialogueText.text = sentence;
    }

/*    IEnumerator TypeSentence (string sentence)
    {
      dialogueText.text = "";
      foreach (char letter in sentence.ToCharArray())
      {
        dialogueText.text += letter;
        yield return null;
      }
    } */

    void EndDialogue()
    {
      Debug.Log("End of Conversation");
      animator.SetBool("IsOpen", false);
    }
}
