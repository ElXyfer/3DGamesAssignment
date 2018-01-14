using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;

public class EnemyHealth : MonoBehaviour {

    public GameObject wallet;
    public GameObject coin;
    public int EnemyHealthPoints = 10;
    public int attackDamage = 5;

    Transform enemyLocation;
    GameObject player;
    Animator anim;

    AudioSource slash;




	// Use this for initialization
	void Awake () {
        player = GameObject.FindGameObjectWithTag("Player");
        anim = GetComponent<Animator>();
        enemyLocation = GetComponent<Transform>();
        slash = GetComponent<AudioSource>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            EnemyHealthPoints--;
            anim.SetBool("isHit", true);

            slash.Play();
            if (EnemyHealthPoints < 1)
            {
                print("ADD SOUND TO THIS !");
                anim.SetBool("isDead", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isHit", false);
                anim.SetBool("isIdle", false);

                Invoke("EnemyDefeated", 2);
            }
        }
    }



    public void EnemyDefeated()
    {
        EnemyManager.numberOfEnemies--;
        Destroy(this.gameObject);
        var rand = Random.Range(1, 10);

        for (int i = 0; i < rand; i++)
        {
            // create coins where ememy died 
            var Mycoins = Instantiate(coin, enemyLocation.position, enemyLocation.rotation);

            // place coins in wallet
            Mycoins.transform.parent = wallet.transform;
        }
    }

}
