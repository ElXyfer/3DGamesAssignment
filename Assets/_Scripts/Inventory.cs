using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject CurrentWeapon;

	public GameObject WeaponPanel;
	public GameObject weaponIcon;
	private GameObject weaponGUI;


	// Use this for initialization
	void Start () {
		
	}

	void OnTriggerEnter(Collider item) {

		if(item.gameObject.tag == "weapon") {
			GameObject weaponGUI = Instantiate(weaponIcon);
			weaponGUI.transform.SetParent(WeaponPanel.transform);
			CurrentWeapon.SetActive(true);
		}

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
