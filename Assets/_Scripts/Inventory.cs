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
    //[SerializeField] float coinAmount;
    public bool QuestItemAquired;


    public GameObject inventoryPanel;
    public GameObject[] inventoryIcons;



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
            coinAmount++;
            SetCoinText();
        }

        if(item.gameObject.CompareTag("Item") && MyDialogue.InteractionCounter >= 1) {
            QuestItemAquired = true;
        }

        foreach (Transform child in inventoryPanel.transform)
        {
            if (child.gameObject.tag == item.gameObject.tag)
            {
                string c = child.Find("Text").GetComponent<Text>().text;
                int tcount = System.Int32.Parse(c) + 1;
                child.Find("Text").GetComponent<Text>().text = "" + tcount;
                return;
            }


        }

        GameObject gameItem;
        if (item.gameObject.tag == "apple")
        {
            gameItem = Instantiate(inventoryIcons[0]);
            gameItem.transform.SetParent(inventoryPanel.transform);
        }
        else if (item.gameObject.tag == "banana")
        {
            gameItem = Instantiate(inventoryIcons[1]);
            gameItem.transform.SetParent(inventoryPanel.transform);
        }
        else if (item.gameObject.tag == "fish")
        {
            gameItem = Instantiate(inventoryIcons[2]);
            gameItem.transform.SetParent(inventoryPanel.transform);
        }

    }

    public void SetCoinText()
    {
        coinText.text = "Coins: " + coinAmount.ToString();
    }

}
