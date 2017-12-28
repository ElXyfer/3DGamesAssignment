using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour {

    public Text nameText;
    public Text dialogueText;
    public int sentenceCount;

    private Queue<string> setences;
    private Queue<string> secondRoundSetences;


    public Animator anim;
    public bool DialogBoxIsShowing = false;

    public GameObject player;
    PlayerController playerController;




    private void Start()
    {

        DialogBoxIsShowing = false;
        setences = new Queue<string>();
        secondRoundSetences = new Queue<string>();
        playerController = player.GetComponent<PlayerController>();


    }




    //public void ChooseDialoguePath(Dialogue dialogue) {
    //    if(DialogueTrigger.NumberOfInteractions <= 0) {
    //        StartSecondRoundDialogue(dialogue);
    //    } else {
    //        StartDialogue(dialogue);
    //    }
    //}


    public void StartDialogue(Dialogue dialogue)
    {
        anim.SetBool("isOpen", true);
        DialogBoxIsShowing = true;

        if (DialogBoxIsShowing == true)
        {
            /// playerController.PlayerUnableToMove();
        }
        nameText.text = dialogue.name;

        setences.Clear();

        foreach (string sentence in dialogue.setences)
        {
            setences.Enqueue(sentence);
        }

        //foreach (string sentence2 in dialogue.secondRoundSetences)
        //{
        //    secondRoundSetences.Enqueue(sentence2);
        //}

        print("Current interaction is " + DialogueTrigger.NumberOfInteractions);
        //if(DialogueTrigger.NumberOfInteractions == 0) {
        //    DisplayNextSentence();
        //} else if(DialogueTrigger.NumberOfInteractions == 1) {
        //    contBtn.onClick.RemoveAllListeners();
        //    contBtn.onClick.AddListener(() => StartSecondRoundDialogue(dialogue));

        //}



        DisplayNextSentence();

            //if(DialogueTrigger.NumberOfInteractions >= 1) {
            ////contBtn.onClick.RemoveAllListeners();
            ////contBtn.onClick.AddListener(() => StartSecondRoundDialogue(dialogue));
            //DisplaySecondRoundSentence();
            //} else {
            //    DisplayNextSentence();
            //}

       
    }

    public void DisplayNextSentence()
    {
        print("Sentences count is " + setences.Count);
        if (setences.Count == 0)
        {
            EndDialogue();
            return;
        }

        dialogueText.text = "";

        string sentence = setences.Dequeue();

        dialogueText.text = sentence;

        //StopAllCoroutines();
        //StartCoroutine(TypeSentence(sentence));
    }

    public void StartSecondRoundDialogue(Dialogue dialogue) {
        anim.SetBool("isOpen", true);
        DialogBoxIsShowing = true;

        nameText.text = dialogue.name;

        foreach (string sentence in dialogue.secondRoundSetences)
        {
            secondRoundSetences.Enqueue(sentence);
        }

        DisplaySecondRoundSentence(); 

    }

    public void DisplaySecondRoundSentence() 
    {       
        print("Second round setences count is " + secondRoundSetences.Count);
        if (secondRoundSetences.Count == 16)
        {

            EndDialogue();
            return;
        }

        dialogueText.text = "";

        string sentence2 = secondRoundSetences.Dequeue();

        dialogueText.text = sentence2;
    }

    //IEnumerator TypeSentence (string sentence){
    //    dialogueText.text = "";
    //    foreach(char letter in sentence.ToCharArray()){
    //        dialogueText.text += letter;
    //        yield return null;
    //    }
    //}

    void EndDialogue(){
        anim.SetBool("isOpen", false);
        DialogBoxIsShowing = false;
    }

}
