using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyManager : MonoBehaviour {

    public GameObject enemy;
    public GameObject enemiesFolder;
    public float spawnTime = 50f;
    public int enemyAmount;
    public Transform[] spawnPoints;
    public static int numberOfEnemies;


    // Use this for initialization
    void Start()
    {
        InvokeRepeating("Spawn", spawnTime, spawnTime);

    }

    void Spawn()
    {
        if (numberOfEnemies < enemyAmount)
        {
           // PlayerHealth.playerInstance.showHealth();

            int spawnPointIndex = Random.Range(0, spawnPoints.Length);

            var myEnemies = Instantiate(enemy, spawnPoints[spawnPointIndex].position, spawnPoints[spawnPointIndex].rotation);
            numberOfEnemies++;
            myEnemies.transform.parent = enemiesFolder.transform;

        }


    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
