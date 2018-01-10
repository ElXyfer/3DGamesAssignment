﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EatingFood : MonoBehaviour {

    GameItem gameItem;
    public GameObject gameItemSound;

    private void Awake()
    {
        gameItem = gameItemSound.GetComponent<GameItem>();
    }

    public void EatFood()
    {
        int itemClickedOn = System.Int32.Parse(this.transform.Find("Text").GetComponent<Text>().text);

        if (itemClickedOn > 0)
        {
            int tcount = itemClickedOn - 1;
            this.transform.Find("Text").GetComponent<Text>().text = "" + tcount;
            gameItem.AppleBite();
            PlayerHealth.playerInstance.AddHealth();

        } else {
            Destroy(this.gameObject);
        }
    } 
}
