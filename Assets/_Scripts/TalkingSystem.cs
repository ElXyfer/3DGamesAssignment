using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class TalkingSystem : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    int sentenceCount;
    int secondSentencesCount;
    Dialogue tsDialogue;

    public Animator anim;
    public bool DialogBoxIsShowing = false;

    public GameObject player;
    PlayerController playerController;

    public GameObject btn;

    Button contBtn;

    int clickCounter;
    int clickCountIndex;


    private void Start()
    {

        DialogBoxIsShowing = false;
        playerController = player.GetComponent<PlayerController>();
        contBtn = btn.GetComponent<Button>();
        contBtn.onClick.AddListener(() => ButtonClick());

    }

    public void ButtonClick()
    {
        clickCounter++;
        clickCountIndex = clickCounter - 1;
       
        print(clickCounter);

        if(clickCountIndex < sentenceCount){
            dialogueText.text = tsDialogue.setences[clickCountIndex];
            if(clickCountIndex == tsDialogue.setences.Length - 1) {
                anim.SetBool("isOpen", false);
            }
        }

        //if (clickCountIndex < secondSentencesCount)
        //{
        //    dialogueText.text = tsDialogue.secondRoundSetences[clickCountIndex];
        //    if (clickCountIndex == tsDialogue.secondRoundSetences.Length - 1)
        //    {
        //        anim.SetBool("isOpen", false);
        //    }
        //}

    }



    public void StartDialogue(Dialogue dialogue)
    {
        tsDialogue = dialogue;
        DialogBoxIsShowing = true;
        anim.SetBool("isOpen", true);
        nameText.text = dialogue.name;

        sentenceCount = tsDialogue.setences.Length;

        secondSentencesCount = tsDialogue.secondRoundSetences.Length;


        //print(sentenceCount);
        //print(clickCounter);
        foreach(string sentence in tsDialogue.setences){
            print(sentence);
        }



    }



}
