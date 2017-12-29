using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class DialogueSystem : MonoBehaviour
{

    public Text nameText;
    public Text dialogueText;

    public Animator anim;
    public GameObject player;
    public GameObject btn;

    Dialogue tsDialogue;
    PlayerController playerController;
    Inventory inventory;
    Button contBtn;

    int clickCounter;
    int clickCountIndex;
    int sentenceCount;
    int secondSentencesCount;
    int midSentencesCount;

    bool DialogBoxIsShowing = false;
    bool ActiveQuest = false;

    private void Start()
    {

        DialogBoxIsShowing = false;
        playerController = player.GetComponent<PlayerController>();
        contBtn = btn.GetComponent<Button>();
        contBtn.onClick.AddListener(() => ButtonClick());
        inventory = player.GetComponent<Inventory>();

    }

    public void ButtonClick()
    {
        clickCounter++;
        clickCountIndex = clickCounter - 1;

       
        print(clickCounter);

        if (ActiveQuest == false)
        {
            if (clickCountIndex < sentenceCount)
            {
                dialogueText.text = tsDialogue.setences[clickCountIndex];
                if (clickCountIndex == tsDialogue.setences.Length - 1)
                {
                    anim.SetBool("isOpen", false);
                    //MyDialogue.InteractionCounter++;
                    ActiveQuest = true;
                    clickCounter = 0;
                    if(MyDialogue.InteractionCounter == 2 && Inventory.coinAmount > 50) {
                       print("You can enter"); 
                    }
                }
            }
        }

        if(ActiveQuest == true && !inventory.QuestItemAquired) {
            if (clickCountIndex < midSentencesCount)
            {
                dialogueText.text = tsDialogue.midRoundSentences[clickCountIndex];
                if (clickCountIndex == tsDialogue.midRoundSentences.Length - 1)
                {
                    anim.SetBool("isOpen", false);
                    clickCounter = 0;
                }
            }
        }

        if(inventory.QuestItemAquired == true) {
            if (clickCountIndex < secondSentencesCount)
            {
                dialogueText.text = tsDialogue.secondRoundSetences[clickCountIndex];
                if (clickCountIndex == tsDialogue.secondRoundSetences.Length - 1)
                {
                    anim.SetBool("isOpen", false);
                    ActiveQuest = false;
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

        midSentencesCount = tsDialogue.secondRoundSetences.Length;

    }



}
