using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Inventory : MonoBehaviour {

	public GameObject CurrentWeapon;
	public GameObject weaponHand;
	private GameObject TestWP;

	public GameObject WeaponPanel;
	public GameObject weaponIcon;
	private GameObject weaponGUI;


	void OnTriggerEnter(Collider item) {

		if(item.gameObject.tag == "weapon") {
			GameObject weaponGUI = Instantiate(weaponIcon);
			weaponGUI.transform.SetParent(WeaponPanel.transform);

//			GameObject TestWP = Instantiate(CurrentWeapon);
//			TestWP.transform.SetParent(weaponHand.transform);
		}

	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
