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
        if(this.gameObject.tag == "MissionNPC") {
            FindObjectOfType<DialogueSystem>().StartDialogue(dialogue);
            InteractionCounter = 2;
            myRadar.SetActive(true);
        }

    }

    void OnTriggerExit(Collider other)
    {
        if (this.gameObject.tag == "MissionNPC")
        {
            anim.SetBool("isOpen", false);
        }
    }
}
