using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;
    public Text contBtnText;
    public GameObject dialogueBox;
    public GameObject player;
    public GameObject[] buttons;
    public GameObject fazerGate;
    public GameObject quests;

    Dialogue tsDialogue;
    PlayerController playerController;
    QuestManager questManager;
    DoorController doorController;
    Inventory inventory;
    Button contBtn;
    Button yesBtn;

    int clickCounter;
    int clickCountIndex;
    int sentenceCount;
    int secondSentencesCount;
    int thirdSentencesCount;

    bool DialogBoxIsShowing;
    bool ActiveQuest;
    bool hasEngaged;

    private void Start()
    {

        playerController = player.GetComponent<PlayerController>();
        doorController = fazerGate.GetComponent<DoorController>();
        contBtn = buttons[0].GetComponent<Button>();
        yesBtn = buttons[1].GetComponent<Button>();
        //contBtnText = buttons[0].GetComponent<Text>();
        contBtn.onClick.AddListener(() => ButtonClick());
        yesBtn.onClick.AddListener(() => YesButton());
        inventory = player.GetComponent<Inventory>();
        questManager = quests.GetComponent<QuestManager>();

    }

    public void YesButton()
    {
        clickCounter++;
        clickCountIndex = clickCounter - 1;

        if (Inventory.coinAmount >= 1)
        {
            RevertToContinueState();
            hasEngaged = true;
            print("Quest is " + ActiveQuest);
            print("Engaged is " + hasEngaged);

            doorController.OpenGate();

            dialogueText.text = tsDialogue.thirdRoundSetences[clickCountIndex];
            if (clickCountIndex == tsDialogue.thirdRoundSetences.Length - 1)
            {
                dialogueBox.SetActive(false);
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
            dialogueBox.SetActive(false);
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
                        yesBtn.gameObject.SetActive(true);
                        dialogueText.text = "Would you like to enter?";
                        contBtnText.text = "No";
                        dialogueBox.SetActive(true);

                    } else if(MyDialogue.InteractionCounter == 3) {
                        dialogueBox.SetActive(false);
                        questManager.questObjects[0].SetActive(true);
                    } else if (MyDialogue.InteractionCounter == 4){
                        ActiveQuest = false;
                        dialogueBox.SetActive(false);
                    }
                    else {
                        dialogueBox.SetActive(false);
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
                    RevertToContinueState();
                    hasEngaged = true;
                }
                dialogueText.text = tsDialogue.secondRoundSetences[clickCountIndex];
                if (clickCountIndex == tsDialogue.secondRoundSetences.Length - 1)
                {
                    dialogueBox.SetActive(false);
                    clickCounter = 0;
                }
            }
        }

        if(inventory.QuestItemAquired) {
            if (clickCountIndex < thirdSentencesCount)
            {
                dialogueText.text = tsDialogue.thirdRoundSetences[clickCountIndex];
                if (clickCountIndex == tsDialogue.thirdRoundSetences.Length - 1)
                {
                    ActiveQuest = false;
                    dialogueBox.SetActive(false);
                    inventory.QuestItemAquired = false;
                    clickCounter = 0;
                }
            }
        }



    } // Button click end



    public void StartDialogue(Dialogue dialogue)
    {
        tsDialogue = dialogue;
        DialogBoxIsShowing = true;
        dialogueBox.SetActive(true);

        nameText.text = dialogue.name;

        sentenceCount = tsDialogue.setences.Length;

        secondSentencesCount = tsDialogue.secondRoundSetences.Length;

        thirdSentencesCount = tsDialogue.thirdRoundSetences.Length;

    }

    void RevertToContinueState() {
        contBtnText.text = "Continue";
        yesBtn.gameObject.SetActive(false);
    }



}
