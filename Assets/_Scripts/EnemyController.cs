using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

	public Transform player;
	public Transform head;
	Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	public float rotSpeed = 0.2f;
	public float speed = 1.5f;
	float accuracyWP = 2.0f;
	private HitDetection hitDect;

	// Use this for initialization
	void Start () {
		hitDect = head.GetComponent<HitDetection>();
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update () {

	//if(hitDect.EnemyHealth <= 0) return;

		// work out the direction the player is to gaurd
		Vector3 direction = player.position - this.transform.position;

		// looking at angle between player and guard on y axis
		direction.y = 0;
		float angle = Vector3.Angle(direction, head.forward);

			if(state == "patrol" && waypoints.Length > 0)
			{ 
				// start walking
				anim.SetBool("isWalking", true);
				anim.SetBool("isIdle", false);
				anim.SetBool("isAttacking", false);

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

			// if distance between gaurd and player is < 10 and the angle is < 90 Degre or persuing is active 
			if(Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 90 || state == "persuing"))
			{
				// start walking and chasing
				state = "persuing";

				// calculate rotaion to the player and start turning
				this.transform.rotation = Quaternion.Slerp(this.transform.rotation,Quaternion.LookRotation(direction), 0.1f);

				// if close, attack
				if(direction.magnitude > 0.9)
				{
					this.transform.Translate(0,0, Time.deltaTime * speed);
					anim.SetBool("isWalking", true);
					anim.SetBool("isAttacking", false);

				}
				else 
				{
					anim.SetBool("isAttacking", true);
					anim.SetBool("isWalking", false);
				}
			} 
			else 
			{	
				state = "patrol";
			}
		}
	}
		

