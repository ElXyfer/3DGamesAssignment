using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class GameItem : MonoBehaviour {

    public AudioClip[] mySounds;
    CreateRadarObject radObject;

	// Use this for initialization
	void Awake () {
        radObject = GetComponent<CreateRadarObject>();
	}

	void OnTriggerEnter(Collider item) {
		
        if (this.gameObject.tag == "weapon" || this.gameObject.tag == "Item" || this.gameObject.tag == "banana" || this.gameObject.tag == "fish" || this.gameObject.tag == "coin" || this.gameObject.tag == "apple")
        {
            ItemCollected();
            Destroy(this.gameObject);
        }

        if (this.gameObject.tag == "scroll")
        {
            ItemCollected();
            radObject.OnDestroy();
            this.gameObject.SetActive(false);
        }


	}

    public void ItemCollected() {
        AudioSource.PlayClipAtPoint(mySounds[0], transform.position, 1f);
    }

    public void AppleBite() {
        AudioSource.PlayClipAtPoint(mySounds[1], transform.position, 1f);
    }
    // Update is called once per frame
    void Update () {
		transform.Rotate (new Vector3 (15, 30, 45) * Time.deltaTime);
	}
}
