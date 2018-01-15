using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {

    public Transform Player;

    MySceneManager mySceneManager;
	// Use this for initialization
	void Awake () {
        mySceneManager = GetComponent<MySceneManager>();
        print("fluke" + Player.position);
        //if(Player.position.x == 48) {
        //    Player.transform.position = new Vector3(45.45f, 43.17f, 484.45f);;

        //} else {
            Player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
            Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("pos"), 0);
            print("The x position from prefs is" + PlayerPrefs.GetFloat("x"));
            print("The defult position is" + Player.position.x);
        //}

    }
	
	// Update is called once per frame
	void Update () {
		
	}

    public void SaveMyGame(bool Quit) {
        PlayerPrefs.SetFloat("x", Player.position.x);
        PlayerPrefs.SetFloat("y", Player.position.y);
        PlayerPrefs.SetFloat("z", Player.position.z);
        PlayerPrefs.SetFloat("pos", Player.eulerAngles.y);

        if(Quit) {
            Time.timeScale = 1;
            mySceneManager.LoadMainMenuScene();
        }
    }
}
