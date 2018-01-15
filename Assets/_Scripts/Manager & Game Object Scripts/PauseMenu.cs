using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    Animator anim;
    public GameObject[] buttons;
     
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
        buttons[0].SetActive(false);
        buttons[1].SetActive(false);
        buttons[2].SetActive(false);
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (Time.timeScale == 1)
            {
                anim.SetTrigger("Pause");
                buttons[0].SetActive(true);
                buttons[1].SetActive(true);
                buttons[2].SetActive(true);
                Invoke("timeScalePause", 3);
            }

        }
	}

    public void timeScalePause() {
        Time.timeScale = 0;
    }



}
