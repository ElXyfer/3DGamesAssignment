using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;
[RequireComponent(typeof(AudioSource))]

public class MySceneManager : MonoBehaviour {



    public Button[] buttons;
 
    AudioSource mysound;

    public GameObject[] myGameObjects;
    Animator anim;

	// Use this for initialization
	void Start () {
        

        mysound = GetComponent<AudioSource>();
        Scene currentScene = SceneManager.GetActiveScene();

        if (currentScene.name == "MainMenu")
        {
            buttons[0].onClick.AddListener(() => LoadGameScene());
            buttons[1].onClick.AddListener(() => LoadSettingsScene());
        }

        if (currentScene.name == "Settings")
        {
            buttons[0].onClick.AddListener(() => LoadGameScene());
        }

        if(currentScene.name == "Game") {
            anim = myGameObjects[0].GetComponent<Animator>();

            buttons[0].onClick.AddListener(() => ResumeGame());

            buttons[2].onClick.AddListener(() => LoadMainMenuScene());
        }
 	}
	
	// Update is called once per frame
	void Update () {

        //if (currentScene.name == "Death")
        //{
        //    if (!mysound.isPlaying)
        //    {
        //        LoadGameScene();
        //    }
        //}
        
    }

    public void ResumeGame() {
        mysound.Play();
        anim.SetTrigger("Resume");
        Time.timeScale = 1;
    }


    public void LoadGameScene() {
            mysound.Play();
            SceneManager.LoadScene("Game");

    }

    public void LoadMainMenuScene()
    {
        mysound.Play();
        SceneManager.LoadScene("MainMenu");

    }

    public void LoadDeathScene()
    {
        mysound.Play();
        SceneManager.LoadScene("Death");
    }


    public void LoadSettingsScene()
    {
        mysound.Play();
        myGameObjects[1].SetActive(true);
        buttons[0].gameObject.SetActive(false);
        buttons[1].gameObject.SetActive(false);
        buttons[2].gameObject.SetActive(false);
       // SceneManager.LoadScene("Settings");
    }

    //void CheckSound (){
    //    if (!mysound.isPlaying)
    //    {
    //        LoadGameScene();
    //    }
    //}

    //public void onSpawn()
    //{

    //    // respwan to check point
    //    transform.position = CheckPointManager.checkPointPosition;

    //    // half players coins
    //    Inventory.coinAmount = Inventory.coinAmount / 2;

    //    //update coin text
    //    inventory.SetCoinText();
    //}



}
