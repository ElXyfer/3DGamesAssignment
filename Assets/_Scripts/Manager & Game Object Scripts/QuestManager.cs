using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestManager : MonoBehaviour {

    public string[] questStatus;
    public GameObject[] questObjects;
    public GameObject[] lights;

	// Use this for initialization
	void Start () {
        
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    public void FirstQuest() {
        questStatus[0] = "complete";
        lights[0].SetActive(false);
        print("first quest done"); 
    }

    public void SecondQuest() {

        questStatus[1] = "complete";
        lights[1].SetActive(false);
        print("second quest done");
    }

    public void ThirdQuest()
    {
        questStatus[2] = "complete";
        print("third quest done");
    }
}
