using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    bool triggered;

    private void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!triggered){
            if(other.tag == "Player"){
                print("Triggered");
                Trigger();
            }
        }
    }

    void Trigger(){
        CheckPointManager.checkPointPosition = transform.position;
        triggered = true;
    }
}
