using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour {

    bool triggered;

    void Start()
    {
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!triggered){
            if(other.tag == "Player"){
                print("Check point entered");
                Trigger();
            }
        }
    }

    void Trigger(){
        CheckPointManager.checkPointPosition = transform.position;
        triggered = true;
    }
}
