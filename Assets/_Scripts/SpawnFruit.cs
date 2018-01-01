using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnFruit : MonoBehaviour {

    public GameObject fruit;
    int spawnNumber = 3;

    void Spawn(){
        for (int i = 0; i < spawnNumber; i++) {
            Vector3 fruitPosition = new Vector3(this.transform.position.x + Random.Range(-1.0f, 1.0f), this.transform.position.y + Random.Range(1.35f, 1.35f), this.transform.position.z + Random.Range(-1.0f, 1.0f));
            Instantiate(fruit, fruitPosition, Quaternion.identity);
        }
    }

    private void Start()
    {
        Spawn();
    }
}
