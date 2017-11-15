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
    private int count = 0;


	// Use this for initialization
	void Start () {
        SetCoinText();
	}

	void OnTriggerEnter(Collider item) {

		if(item.gameObject.tag == "weapon") {
			weaponGUI = Instantiate(weaponIcon);
			weaponGUI.transform.SetParent(WeaponPanel.transform);
			CurrentWeapon.SetActive(true);
		}

        if(item.gameObject.CompareTag("coin")){
            count++;
            SetCoinText();
        }

	}

    void SetCoinText(){
        coinText.text = "Coins: " + count.ToString();
    }

	
	// Update is called once per frame
	void Update () {
		
	}
}
