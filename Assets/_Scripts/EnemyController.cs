using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour {

    public GameObject enemy;
    public float EnemyHealth;
    public float speed;
    public float rotSpeed;
	public Transform playerTarget;
	public Transform head;

	string state = "patrol";
	public GameObject[] waypoints;
	int currentWP = 0;
	float accuracyWP = 2.0f;
    Animator anim;



	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
	}
	
	// Update is called once per frame
    void Update()
    {

        if (EnemyHealth <= 0) return;

        // work out the direction the player is to gaurd
        Vector3 direction = playerTarget.position - this.transform.position;

        // looking at angle between player and guard on y axis
        direction.y = 0;
        float angle = Vector3.Angle(direction, head.forward);

        if (state == "patrol" && waypoints.Length > 0)
        {
            // start walking
            anim.SetBool("isWalking", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isHit", false);

            // checks distance between guard and waypoint
            if (Vector3.Distance(waypoints[currentWP].transform.position, transform.position) < accuracyWP)
            {
                // goes through waypoints
                currentWP++;
                if (currentWP >= waypoints.Length)
                {
                    currentWP = 0;
                }
            }

            // rotate guard to waypoint
            direction = waypoints[currentWP].transform.position - transform.position;

            // turn guard to waypoint
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

            // move guard towards waypoint
            this.transform.Translate(0, 0, Time.deltaTime * speed);
        }

        // if distance between gaurd and player is < 10 and the angle is < 90 Degre or persuing is active 
        if (Vector3.Distance(playerTarget.position, this.transform.position) < 10 && (angle < 90 || state == "persuing"))
        {
            // start walking and chasing
            state = "persuing";

            // calculate rotaion to the player and start turning
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            // if close, attack
            if (direction.magnitude > 1.5)
            {
                this.transform.Translate(0, 0, Time.deltaTime * speed);
                anim.SetBool("isWalking", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isHit", false);

            }
            else 
            {
                anim.SetBool("isAttacking", true);
                anim.SetBool("isWalking", false);
                anim.SetBool("isHit", false);
                anim.SetBool("isIdle", false);
            }
        }
        else
        {
            state = "patrol";
        }
    } // End update

    void OnTriggerEnter(Collider other)
    {
        if (other.gameObject.tag == "weapon")
        {
            EnemyHealth --;
            anim.SetBool("isHit", true);
            //anim.SetBool("isAttacking", false);
            //anim.SetBool("isWalking", false);
            //anim.SetBool("isHit", false);
            //anim.SetBool("isIdle", false);
            print("Hit" + EnemyHealth);
            if(EnemyHealth < 0) {
                print("ADD SOUND TO THIS !");
                anim.SetBool("isDead", true);
                anim.SetBool("isAttacking", false);
                anim.SetBool("isWalking", false);
                anim.SetBool("isHit", false);
                anim.SetBool("isIdle", false);

                Invoke("EnemyDefeated", 5);
            }
        }
    }

    void EnemyDefeated()
    {
        Destroy(enemy);
    }


} // End main class
		

