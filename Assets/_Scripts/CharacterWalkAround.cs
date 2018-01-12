using UnityEngine;
using UnityEngine.AI;

public class CharacterWalkAround : MonoBehaviour {

	public Transform player;
	Animator anim;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	float accuracyWP = 2.0f;
    NavMeshAgent agent;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        agent = GetComponent<NavMeshAgent>();
	}
	
	// Update is called once per frame
	void Update () {

		// work out the direction the player is to gaurd
		Vector3 direction = player.position - this.transform.position;

		direction.y = 0;
        float angle = Vector3.Angle(direction, player.forward);

			if(state == "patrol" && waypoints.Length > 0)
			{ 
				// start walking
				anim.SetBool("isWalking", true);

				// checks distance between npc and waypoint
				if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
				{
					// goes through waypoints randomly
					currentWP = Random.Range(0,waypoints.Length);
				
				}

            agent.SetDestination(waypoints[currentWP].transform.position);

			}

		}
	}
		

