using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitDetection : MonoBehaviour {

	public float EnemyHealth;
	public GameObject enemy;
	//public GameObject[] hands;
	Animator anim;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}

	void OnTriggerEnter(Collider other)
	{
//		if(other.gameObject.tag == "Hands") {
//			EnemyHealth -= 1f;
//			anim.SetBool("isHit", true);
//			print("Hit" + 1);
//		}
	}

	
	// Update is called once per frame
	void Update () {
		if(EnemyHealth <= 0){
			anim.SetBool("Defeated", true);
			//Destroy(enemy);
		}
	}
}
