using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.AI;

public class EnemyController : MonoBehaviour {
    
    Animator anim;
    private EnemyHealth enemyHealth;
    public float speed;
    public float rotSpeed;
    public Transform playerTarget;
    public Transform head;

    string state = "patrol";
    int currentWP = 0;
    float accuracyWP = 2.0f;
    public GameObject[] waypoints;

    // Use this for initialization
    void Awake()
    {
        anim = GetComponent<Animator>();
        enemyHealth = GetComponent<EnemyHealth>();
    }

    // Update is called once per frame
    void Update()
    {

        // work out the direction the player is to gaurd
        Vector3 direction = playerTarget.position - this.transform.position;
        direction.y = 0;
        // looking at angle between player and guard on y axis
       
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
                currentWP = Random.Range(0, waypoints.Length);
            }

            // rotate guard to waypoint
            direction = waypoints[currentWP].transform.position - transform.position;

            // turn guard to waypoint
            this.transform.rotation = Quaternion.Slerp(transform.rotation, Quaternion.LookRotation(direction), rotSpeed * Time.deltaTime);

            // move guard towards waypoint
            this.transform.Translate(0, 0, Time.deltaTime * speed);
        }

        // if distance between gaurd and player is < 10 and the angle is < 90 Degre or persuing is active 
        if (Vector3.Distance(playerTarget.position, this.transform.position) < 10 && (angle < 180 || state == "persuing"))
        {
            // start walking and chasing
            state = "persuing";

            // calculate rotaion to the player and start turning
            this.transform.rotation = Quaternion.Slerp(this.transform.rotation, Quaternion.LookRotation(direction), 0.1f);

            // if out of range keep persuing 
            if (direction.magnitude > 1)
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
            anim.SetBool("isWalking", true);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isHit", false);
            anim.SetBool("isIdle", false);        }
    } // End update

} // End main class
