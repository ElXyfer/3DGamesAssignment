﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider item) {
		
		if(this.gameObject.tag == "weapon"){
			//anim.SetBool("PickingUp", true);
			Destroy(this.gameObject);
		}

        if(this.gameObject.CompareTag("coin")){
            Destroy(this.gameObject);
        }
        if (this.gameObject.tag == "Item")
        {
            Destroy(this.gameObject);
        }

	}


	
	// Update is called once per frame
	void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
