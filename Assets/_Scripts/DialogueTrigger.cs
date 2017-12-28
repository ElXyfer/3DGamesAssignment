using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DialogueTrigger : MonoBehaviour {

    public Dialogue dialogue;
    public bool SpokenTo = false;
    public bool isAMissionCharacter = false;
    public static int NumberOfInteractions;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if (this.gameObject.tag == "NPC")
        {
            TriggerDialogue();
            NumberOfInteractions++;
        }
    }

    public void TriggerDialogue(){
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }

    public void TriggerSecondRoundDialogue()
    {
        //FindObjectOfType<DialogueSystem>().StartSecondRoundDialogue(dialogue);
    }

}
