using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class MyDialogue : MonoBehaviour {

    public Animator anim;
    public Dialogue dialogue;
    public static int InteractionCounter;
    public GameObject myRadar;
    Radar radar;

	// Use this for initialization
	void Start () {

    }

	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other){
        if(this.gameObject.tag == "CaveOldMan") {
            FindDialogueSystem();
            myRadar.SetActive(true);
        }
        if(this.gameObject.tag == "FazerGuard") {
            FindDialogueSystem();
            InteractionCounter = 2;
           
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "CaveOldMan" || this.gameObject.tag == "FazerGuard")
        {
            anim.SetBool("isOpen", false);
        }
    }

    void FindDialogueSystem() {
        FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
    }
}
