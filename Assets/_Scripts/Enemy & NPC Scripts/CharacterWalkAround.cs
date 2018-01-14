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
            anim.SetBool("isIdle", false);

				// checks distance between npc and waypoint
				if(Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
				{
					// goes through waypoints randomly
					currentWP = Random.Range(0,waypoints.Length);
				
				}

            agent.SetDestination(waypoints[currentWP].transform.position);

			}



            if (Vector3.Distance(player.position, this.transform.position) < 10 && (angle < 90 || state == "persuing"))
            {
                if (this.gameObject.tag == "OldFather")
                {         // start walking and chasing
                    state = "persuing";

                    // calculate rotaion to the player and start turning
                    this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

                    // if out of range keep persuing
                    if (direction.magnitude > 2)
                    {
                        //this.transform.Translate(0, 0, Time.deltaTime * speed);

                        if (agent.isActiveAndEnabled)
                        {
                            agent.SetDestination(player.transform.position);
                        }

                    anim.SetBool("isWalking", true);
                    anim.SetBool("isIdle", false);
                    }
                    else
                    {
                        anim.SetBool("isIdle", true);
                        anim.SetBool("isWalking", false);
                    }
                }
        } else {
            state = "patrol";
        }
	}



}
		

