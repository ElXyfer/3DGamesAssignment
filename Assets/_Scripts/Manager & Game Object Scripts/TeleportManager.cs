using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportManager : MonoBehaviour {

    public GameObject[] teleLocations;
    public Transform player; 
	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter(Collider other)
    {
        if(this.gameObject.tag == "Teleportation") {
            player.transform.position = teleLocations[1].transform.position;
        }
    }
}
