using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogue : MonoBehaviour {

    public Dialogue dialogue;

    bool DisplayDialogueBox = false;
    bool ActiveQuest = false;

    public Text nameText;
    public Text dialogueText;

    public Animator anim;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}


    void OnTriggerEnter(Collider other){
        if(this.gameObject.tag == "Item") {
            print("Im on it");

            FindObjectOfType<TalkingSystem>().StartDialogue(dialogue);
            //DisplayDialogueBox = true;
            //anim.SetBool("isOpen", true);

            //nameText.text = dialogue.name;

            //dialogueText.text = dialogue.setences[0];
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "Item")
        {
            DisplayDialogueBox = false;
            anim.SetBool("isOpen", false);
        }
    }
}
