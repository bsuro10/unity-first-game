using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue<DialogueElement> sentences;
    public Animator animator;
    public Text dialogueText;
    public Text nameText;

    void Start()
    {
        sentences = new Queue<DialogueElement>();
    }

    public void StartDialogue(Dialogue dialogue)
    {
        animator.SetBool("isOpen", true);
        SceneManager.Instance.player.isInDialogue = true;
        sentences.Clear();
        foreach (DialogueElement elements in dialogue.sentences)
        {
            sentences.Enqueue(elements);
        }
        DisplayNextSentence();
    }
    public void DisplayNextSentence()
    {
        if (sentences.Count == 0)
        {
            EndDialogue();
            return;
        }
        DialogueElement dialogueElement = sentences.Dequeue();
        StopAllCoroutines();
        nameText.color = dialogueElement.nameColor;
        nameText.text = dialogueElement.name;
        dialogueText.color = dialogueElement.sentenceColor;
        StartCoroutine(TypeSentence(dialogueElement.sentence));
    }

    // Using CoRoutines help executing a function over sequence of frames
    private IEnumerator TypeSentence (string sentence)
    {
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(0.02f);
        }
    }

    public void EndDialogue()
    {
        animator.SetBool("isOpen", false);
        SceneManager.Instance.player.isInDialogue = false;
    }
}
