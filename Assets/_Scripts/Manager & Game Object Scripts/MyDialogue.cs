using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogue : MonoBehaviour {

    public GameObject dialogueBox;
    public Dialogue dialogue;
    public static int InteractionCounter;
    public GameObject myRadar;

	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other){

        dialogueBox.SetActive(true);
        if(this.gameObject.tag == "NoReplys") {
            myRadar.SetActive(true);
            InteractionCounter = 1;
            FindDialogueSystem();

        }
        if(this.gameObject.tag == "ReplyNPC") {
            InteractionCounter = 2;
            FindDialogueSystem();

        }

        if (this.gameObject.tag == "OldFather")
        {
            InteractionCounter = 3;
            FindDialogueSystem();
        }

        if (this.gameObject.tag == "CryingGirl")
        {
            InteractionCounter = 4;
            FindDialogueSystem();
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "NoReplys" || this.gameObject.tag == "ReplyNPC" || this.gameObject.tag == "ReplyNPC2" || this.gameObject.tag == "OldFather")  
        {
            dialogueBox.SetActive(false);
        }
    }

    void FindDialogueSystem() {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }
}
