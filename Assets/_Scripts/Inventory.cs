using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Inventory : MonoBehaviour {

	public GameObject CurrentWeapon;
	public GameObject WeaponPanel;
	public GameObject weaponIcon;
	GameObject weaponGUI;

    public Text coinText;
    public static int coinAmount;

    public bool QuestItemAquired;



	// Use this for initialization
	void Start () {
        SetCoinText();
        FindObjectOfType<DialogueSystem>();
	}

	void OnTriggerEnter(Collider item) {

		if(item.gameObject.tag == "weapon") {
			weaponGUI = Instantiate(weaponIcon);
			weaponGUI.transform.SetParent(WeaponPanel.transform);
			CurrentWeapon.SetActive(true);
		}

        if(item.gameObject.CompareTag("coin")){
            coinAmount = 60;
            SetCoinText();
        }

        if(item.gameObject.CompareTag("Item") && MyDialogue.InteractionCounter >= 1) {
            QuestItemAquired = true;
        }



	}

    void SetCoinText(){
        coinText.text = "Coins: " + coinAmount.ToString();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
