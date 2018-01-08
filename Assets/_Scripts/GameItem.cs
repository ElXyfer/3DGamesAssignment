using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameItem : MonoBehaviour {


	// Use this for initialization
	void Start () {
	}

	void OnTriggerEnter(Collider item) {
		
        if (this.gameObject.tag == "weapon" || this.gameObject.tag == "Item" || this.gameObject.tag == "apple" || this.gameObject.tag == "banana" || this.gameObject.tag == "fish" || this.gameObject.tag == "coin")
        {
            Destroy(this.gameObject);
        }

	}



    // Update is called once per frame
    void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
