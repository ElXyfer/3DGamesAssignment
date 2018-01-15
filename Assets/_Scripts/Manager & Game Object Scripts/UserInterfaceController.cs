using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UserInterfaceController : MonoBehaviour {

    public GameObject HelpMenu;
    public GameObject volumet;
    // Use this for initialization
    AudioSource mysound;

    // Use this for initialization
    void Awake()
    {

        mysound = GetComponent<AudioSource>();



    }
	
	// Update is called once per frame
	void Update () {
	}

    public void ToggleChanged(bool isOn) {
        HelpMenu.SetActive(isOn);
        volumet.SetActive(true);
        mysound.Play();
    }
}
