using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RespawnFruit : MonoBehaviour {

    public int respawnTime = 5;

    private void OnCollisionEnter()
    {
        this.GetComponent<SphereCollider>().enabled = false;
        this.GetComponent<MeshRenderer>().enabled = false;

        Invoke("Respawn", respawnTime);
    }

    void Respawn(){
        this.GetComponent<SphereCollider>().enabled = true;
        this.GetComponent<MeshRenderer>().enabled = true;
    }
}
