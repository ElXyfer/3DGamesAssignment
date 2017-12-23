using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TownFazerCharacterWalkAround : MonoBehaviour {

	public Transform player;
	Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.2f;
	public float speed = 1.5f;
	float accuracyWP = 2.0f;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

		// work out the direction the player is to gaurd
		Vector3 direction = player.position - this.transform.position;

		// looking at angle between player and guard on y axis
		direction.y = 0;
        float angle = Vector3.Angle(direction, player.forward);

			if(state == "patrol" && waypoints.Length > 0)
			{ 
				// start walking
				anim.SetBool("isWalking", true);


				// checks distance between guard and waypoint
				if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
				{
					// goes through waypoints
					currentWP = Random.Range(0,waypoints.Length);
				
				}

					// rotate guard to waypoint
					direction = waypoints[currentWP].transform.position - transform.position;

					// turn guard to waypoint
					this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

					// move guard towards waypoint
					this.transform.Translate(0,0, Time.deltaTime * speed);
			}

		}
	}
		

