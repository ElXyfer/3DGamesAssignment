using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	private Animator anim;
	public float speed;
	public float runningSpeed;
	public float rotationSpeed = 100.0f;
	public bool isMoving = false;
	// commit test

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		if (Input.GetKeyDown("space")){
			anim.SetBool("isAttacking", true);
			anim.SetBool("isWalking", false);
			anim.SetBool("isRunning", false);
		}
		
		float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(translation != 0) {
			isMoving = true;
			if(isMoving == true){
				speed = 1f;
        	anim.SetBool("isWalking", true);
        	anim.SetBool("isIdle", false);
			anim.SetBool("isRunning", false);
			anim.SetBool("isAttacking", false);

        	if(Input.GetKey(KeyCode.Z)){
				anim.SetBool("isWalking", false);
        		anim.SetBool("isRunning", true);
        		speed = runningSpeed;
        	}
        }

        } 
        else {
			anim.SetBool("isWalking", false);
			anim.SetBool("isIdle", true);
        }
	}
}
