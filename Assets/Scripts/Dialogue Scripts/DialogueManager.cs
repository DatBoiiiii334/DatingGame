using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueManager : MonoBehaviour
{
    public Text nameText;
    public Text DialogueText;
    public int currentSentence;
    public Animator animator;

    public Queue<string> sentences;

    public DialogueScript dialogueScript;

    public GameObject Characteur1;
    public GameObject Characteur2;

    private bool StopDialogue;

    void Start()
    {
        //dialogueScript = GetComponent<DialogueScript>();
        sentences = new Queue<string>();
    }

    public void StartDialogue (DialogueScript dialogue)
    {
        animator.SetBool("IsOpen", true);
        nameText.text = dialogue.name;
        sentences.Clear();
        Characteur1.SetActive(true);
        //dialogueScript.Charactuer.SetActive(true);

        foreach (string sentence in dialogue.sentences) {
            sentences.Enqueue(sentence);
        }
        DisplayNextSentence();
    }

    public void DisplayNextSentence()
    {
        if(sentences.Count == currentSentence) {
            EndDialogue();
            return;
        }
        string sentence = sentences.Dequeue();
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
        //DialogueText.text = sentence; This displays the text without animation
    }

    public void Update()
    {
        string sentence = sentences.Dequeue();
        StopTyping(sentence);
        
    }

    public void StopTyping(string sentence)
    {
        if (Input.GetMouseButtonDown(1)) {
            //StopDialogue = true;
            Debug.Log("Click");
            //DialogueText.text = sentence;
            //StopAllCoroutines();
            StopDialogue = false;
        }
    }

    IEnumerator TypeSentence(string sentence)
    {

        DialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()) {
            DialogueText.text += letter;
            yield return null; //This makes it so that the letters load in per frame
        }

        
    }

    public void EndDialogue()
    {
        animator.SetBool("IsOpen", false);
        //dialogueScript.Charactuer.SetActive(false);
    }
}
