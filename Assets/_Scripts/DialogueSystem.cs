using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;

    private Queue<string> setences;

    public Animator anim;
    public bool DialogBoxIsShowing = false;

    public GameObject player;
    PlayerController playerController;

    private void Start()
    {
        setences = new Queue<string>();
        playerController = player.GetComponent<PlayerController>();
    }

    public void StartDialogue(Dialogue dialogue){

        anim.SetBool("isOpen", true);
        DialogBoxIsShowing = true;

        if(DialogBoxIsShowing == true) {
           /// playerController.PlayerUnableToMove();
        }
        nameText.text = dialogue.name;

        setences.Clear();

        foreach (string sentence in dialogue.setences)
        {
            setences.Enqueue(sentence);
        }

        DisplayNextSentence();

    }

    public void DisplayNextSentence(){
        if(setences.Count == 0) {
            EndDialogue();
            return;
        } 

        string sentence = setences.Dequeue();
        dialogueText.text = sentence;
        StopAllCoroutines();
        StartCoroutine(TypeSentence(sentence));
    }

    IEnumerator TypeSentence (string sentence){
        dialogueText.text = "";
        foreach(char letter in sentence.ToCharArray()){
            dialogueText.text += letter;
            yield return null;
        }
    }

    void EndDialogue(){
        anim.SetBool("isOpen", false);
        DialogBoxIsShowing = false;
    }

}
