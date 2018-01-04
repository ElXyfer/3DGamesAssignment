using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoorController : MonoBehaviour {

    Animator anim;

	// Use this for initialization
	void Start () {
        anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if(this.CompareTag("Gate")) {
            OpenGate();
        }
    }

    public void OpenGate() {
        anim.SetBool("isClosed", false);
        anim.SetBool("isOpenning", true);
        anim.SetBool("isOpen", true);
        Invoke("CloseGate", 10);
    }

    public void CloseGate() {
        anim.SetBool("isClosed", true);
        anim.SetBool("isOpenning", false);
    }
}
