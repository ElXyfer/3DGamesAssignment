using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Text contBtnText;
    public Animator anim;
    public GameObject player;
    public GameObject[] buttons;
    public GameObject fazerGate;


    Dialogue tsDialogue;
    PlayerController playerController;
    DoorController doorController;
    Inventory inventory;
    Button contBtn;
    Button yesBtn;

    int clickCounter;
    int clickCountIndex;
    int sentenceCount;
    int secondSentencesCount;
    int thirdSentencesCount;


    bool DialogBoxIsShowing = false;
    bool ActiveQuest = false;
    bool hasEngaged;

    private void Start()
    {

        DialogBoxIsShowing = false;
        playerController = player.GetComponent<PlayerController>();
        doorController = fazerGate.GetComponent<DoorController>();
        contBtn = buttons[0].GetComponent<Button>();
        yesBtn = buttons[1].GetComponent<Button>();
        //contBtnText = buttons[0].GetComponent<Text>();
        contBtn.onClick.AddListener(() => ButtonClick());
        yesBtn.onClick.AddListener(() => YesButton());
        inventory = player.GetComponent<Inventory>();

    }

    public void YesButton()
    {
        clickCounter++;
        clickCountIndex = clickCounter - 1;

        if (Inventory.coinAmount >= 1)
        {
            RevertToContinueState();
            print("Quest is " + ActiveQuest);
            print("Engaged is " + hasEngaged);
            doorController.OpenGate();

            dialogueText.text = tsDialogue.thirdRoundSetences[clickCountIndex];
            if (clickCountIndex == tsDialogue.thirdRoundSetences.Length - 1)
            {
                
                anim.SetBool("isOpen", false);
                clickCounter = 0;


            }
        } else {
            dialogueText.text = "You don't have enough coins to come in just yet, comeback once you have at least 50 coins";
            RevertToContinueState();
        }
    }

    public void ButtonClick()
    {
        
        clickCounter++;
        clickCountIndex = clickCounter - 1;
       
        if(hasEngaged) {
            hasEngaged = false;
            anim.SetBool("isOpen", false);

        }

        if (ActiveQuest == false && !hasEngaged)
        {
            if (clickCountIndex < sentenceCount)
            {
                dialogueText.text = tsDialogue.setences[clickCountIndex];
                if (clickCountIndex == tsDialogue.setences.Length - 1)
                {
                    ActiveQuest = true;
                    clickCounter = 0;
                    if(MyDialogue.InteractionCounter == 2) {
                        contBtn.transform.position = new Vector3(600f, 60f, 0f);
                        yesBtn.gameObject.SetActive(true);
                        dialogueText.text = "Would you like to enter?";
                        contBtnText.text = "No";

                    } else {
                        anim.SetBool("isOpen", false);
                    }
                }
            }
        }

        if(ActiveQuest == true && !inventory.QuestItemAquired) {
            if (clickCountIndex < secondSentencesCount)
            {
                if (MyDialogue.InteractionCounter == 2)
                {
                    clickCounter = 0;
                    ActiveQuest = false;
                    //anim.SetBool("isOpen", false);
                    RevertToContinueState();
                    hasEngaged = true;

                }
                dialogueText.text = tsDialogue.secondRoundSetences[clickCountIndex];
                if (clickCountIndex == tsDialogue.secondRoundSetences.Length - 1)
                {
                    anim.SetBool("isOpen", false);
                    DialogBoxIsShowing = true;
                    clickCounter = 0;
                }
            }
        }

        if(inventory.QuestItemAquired == true) {
            if (clickCountIndex < thirdSentencesCount)
            {
                dialogueText.text = tsDialogue.thirdRoundSetences[clickCountIndex];
                if (clickCountIndex == tsDialogue.thirdRoundSetences.Length - 1)
                {
                    anim.SetBool("isOpen", false);
                    ActiveQuest = false;
                    DialogBoxIsShowing = true;
                    inventory.QuestItemAquired = false;
                    clickCounter = 0;
                }
            }
        }



    }



    public void StartDialogue(Dialogue dialogue)
    {
        tsDialogue = dialogue;
        DialogBoxIsShowing = true;
        anim.SetBool("isOpen", true);

        nameText.text = dialogue.name;

        sentenceCount = tsDialogue.setences.Length;

        secondSentencesCount = tsDialogue.secondRoundSetences.Length;

        thirdSentencesCount = tsDialogue.thirdRoundSetences.Length;

    }

    void RevertToContinueState() {
        contBtnText.text = "Continue";
        yesBtn.gameObject.SetActive(false);
        contBtn.transform.position = new Vector3(520, 60f, 0f);
    }



}
