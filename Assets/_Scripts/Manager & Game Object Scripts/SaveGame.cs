using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SaveGame : MonoBehaviour {

    public Transform Player;

    MySceneManager mySceneManager;
    QuestManager questManager;
    public GameObject myGameObject;
	// Use this for initialization
	void Awake () {
        mySceneManager = GetComponent<MySceneManager>();
        questManager = myGameObject.GetComponent<QuestManager>();

        print("fluke" + mySceneManager.NewGame);

        if (PlayerPrefs.GetInt("NewGame") == 1){
              
            Player.transform.position = new Vector3(45.45f, 43.17f, 484.45f);;

        } else {
            LoadSavedGame();
        }

    }


    // Update is called once per frame
    void Update () {

            PlayerHealth.playerInstance.UpdateHealthSlider();
	}

    public void SaveMyGame(bool Quit) {
        PlayerPrefs.SetFloat("x", Player.position.x);
        PlayerPrefs.SetFloat("y", Player.position.y);
        PlayerPrefs.SetFloat("z", Player.position.z);
        PlayerPrefs.SetFloat("pos", Player.eulerAngles.y);
        PlayerPrefs.SetInt("coins", Inventory.coinAmount);
        PlayerPrefs.SetFloat("health", PlayerHealth.playerInstance.CurrentPlayerHealth);
        PlayerPrefs.SetString("quest1", questManager.questStatus[0]);
        PlayerPrefs.SetString("quest2", questManager.questStatus[1]);
        PlayerPrefs.SetString("quest3", questManager.questStatus[2]);
        //PlayerPrefs.SetFloat("cx", CheckPointManager.checkPointPosition.x);
        //PlayerPrefs.SetFloat("cy", CheckPointManager.checkPointPosition.y);
        //PlayerPrefs.SetFloat("cz", CheckPointManager.checkPointPosition.z);

        if(Quit) {
            Time.timeScale = 1;
            mySceneManager.LoadMainMenuScene();
        }
    }

    void LoadSavedGame() {
        Player.position = new Vector3(PlayerPrefs.GetFloat("x"), PlayerPrefs.GetFloat("y"), PlayerPrefs.GetFloat("z"));
        Player.eulerAngles = new Vector3(0, PlayerPrefs.GetFloat("pos"), 0);
        Inventory.coinAmount = PlayerPrefs.GetInt("coins", Inventory.coinAmount);
        PlayerHealth.playerInstance.CurrentPlayerHealth = PlayerPrefs.GetFloat("health", PlayerHealth.playerInstance.CurrentPlayerHealth);
        questManager.questStatus[0] = PlayerPrefs.GetString("quest1", "null");
        questManager.questStatus[1] = PlayerPrefs.GetString("quest2", "null");
        questManager.questStatus[2] = PlayerPrefs.GetString("quest3", "null");

    }
}
