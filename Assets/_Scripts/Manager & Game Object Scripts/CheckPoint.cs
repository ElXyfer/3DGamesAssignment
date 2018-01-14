using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class CheckPoint : MonoBehaviour {

    bool triggered;
    AudioSource wizAudio;
    public GameObject checkPointText;

    void Start()
    {
        wizAudio = GetComponent<AudioSource>();
        triggered = false;
    }
    private void OnTriggerEnter(Collider other)
    {
        if(!triggered){
            if(other.tag == "Player"){
                Trigger();
                checkPointText.SetActive(true);
            }
        }
    }

    private void OnTriggerExit(Collider other)
    {
        checkPointText.SetActive(false);

    }

    void Trigger(){
        wizAudio.Play();
        CheckPointManager.checkPointPosition = transform.position;
        triggered = true;
    }
}
