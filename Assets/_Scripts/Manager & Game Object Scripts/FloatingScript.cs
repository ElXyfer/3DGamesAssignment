﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent (typeof(Rigidbody))]
public class FloatingScript : MonoBehaviour {

    public float waterLevel = 0.0f;
    public float waterThreshold = 2.0f;
    public float waterDensity = 0.125f;
    public float downForce = 4.0f;

    float forceFactor;
    Vector3 floatForce;

	// Use this for initialization
	void Start () {
		
	}

	// Update is called once per frame
	void FixedUpdate () {

        if(this.gameObject.tag == "Player"){
            this.enabled = false;
        }

        forceFactor = 1.0f - ((transform.position.y - waterLevel) / waterThreshold);

        if(forceFactor > 0f) {
            floatForce = -Physics.gravity * GetComponent<Rigidbody>().mass * (forceFactor - GetComponent<Rigidbody>().velocity.y * waterDensity);
            floatForce += new Vector3(0.0f, -downForce * GetComponent<Rigidbody>().mass, 0.0f);
            GetComponent<Rigidbody>().AddForceAtPosition(floatForce, transform.position);
        }
	}
}
