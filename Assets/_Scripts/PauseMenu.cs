using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour {

    Animator anim;
     
	// Use this for initialization
	void Awake () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
        if (Input.GetKeyDown(KeyCode.P))
        {
            
            if (Time.timeScale == 1)
            {
                anim.SetTrigger("Pause");
                Invoke("timeScalePause", 3);
            }

        }
	}

    public void timeScalePause() {
        Time.timeScale = 0;
    }



}
