using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    private Queue <string> sentences;
    public TextMeshProUGUI nameText;
    public TextMeshProUGUI dialogueText;
    public Animator animator;
    public GameObject textBox;
    void Start()
    {
        sentences = new Queue <string> ();
        textBox.SetActive(false);
    }

    public void StartDialogue(Dialogue dialogue)
    {
        textBox.SetActive(true);
        animator.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentences.Clear ();

        foreach (string sentence in dialogue.sentences)
        {
            sentences.Enqueue (sentence);
        }
        PlayerMovement.isTalking = true;
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == 0)
        {
            EndDialogue();
            return;
        }

        string sentence = sentences.Dequeue ();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence)
    {
        float waitTime = 0.025f;
        dialogueText.text = "";
        foreach (char letter in sentence.ToCharArray())
        {
            dialogueText.text += letter;
            yield return new WaitForSeconds(waitTime);
        }
    }

    void EndDialogue()
    {
        PlayerMovement.isTalking = false;
        animator.SetBool("isOpen", false);
    }
}
