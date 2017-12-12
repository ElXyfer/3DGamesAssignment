using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

    public float distToGround = 0.75f;
    public float dHeight;


	// Use this for initialization
	void Start () {
		
	}

    void OnTriggerEnter(Collider hC)
    {
        if(hC.gameObject.tag == "heightChecker" && !isGrounded()){
            print("Dead");
        }
    }
	
	// Update is called once per frame
	void Update () {



	}


    bool isGrounded(){
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }

}
