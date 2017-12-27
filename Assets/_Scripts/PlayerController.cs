using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    ///public float PlayerHealth;
	public float speed;
	public float runningSpeed;
    public float fastSwimmingSpeed;
	public float rotationSpeed = 100.0f;
	public bool isMoving = false;
    public bool isSwimming = false;
    float distToGround = 0.75f;

    private Animator anim;
    FloatingScript floatingScript;

	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator>();
        floatingScript = GetComponent<FloatingScript>();
        floatingScript.enabled = false;
	}
	
	// Update is called once per frame
	void Update () {
       
		if (Input.GetKeyDown("space")){
			anim.SetBool("isAttacking", true);
//			anim.SetBool("isWalking", false);
//			anim.SetBool("isRunning", false);
			anim.SetTrigger("Attacking");
		} else {
			anim.SetBool("isAttacking", false);
		}
		
		float translation = Input.GetAxis("Vertical") * speed;
        float rotation = Input.GetAxis("Horizontal") * rotationSpeed;
        translation *= Time.deltaTime;
        rotation *= Time.deltaTime;
        transform.Translate(0, 0, translation);
        transform.Rotate(0, rotation, 0);

        if(translation != 0) {
			isMoving = true;
			if(isMoving == true){
                PlayerIsMoving();
            }

            if(isSwimming == true) {
                isMoving = false;
                PlayerIsSwimming();
            }


        } 
        else {
			anim.SetBool("isWalking", false);
			anim.SetBool("isIdle", true);
        }


	}

    void OnTriggerEnter(Collider hC)
    {
        if (hC.gameObject.tag == "heightChecker" && !isGrounded())
        {
            print("Dead");
        }

        if (hC.gameObject.tag == "Water")
        {
            isSwimming = true;
        }


    }

    private void OnTriggerStay(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isSwimming = true;
        }
        
    }

    private void OnTriggerExit(Collider other)
    {
        if (other.gameObject.tag == "Water")
        {
            isSwimming = false;
            floatingScript.enabled = false;
        }
    }

    public void PlayerIsMoving() {
        speed = 1f;
        anim.SetBool("isWalking", true);
        anim.SetBool("isIdle", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
        anim.SetBool("isSwimming", false);

        if (Input.GetKey(KeyCode.Z))
        {
            anim.SetBool("isWalking", false);
            anim.SetBool("isRunning", true);
            speed = runningSpeed;
        }
    } 


    void PlayerIsSwimming() {
        floatingScript.enabled = true;
        runningSpeed = fastSwimmingSpeed;
        anim.SetBool("isSwimming", true);
        anim.SetBool("isWalking", false);
        anim.SetBool("isIdle", false);
        anim.SetBool("isRunning", false);
        anim.SetBool("isAttacking", false);
    }

    public void PlayerUnableToMove(){
        speed = 0;
        runningSpeed = 0;
        rotationSpeed = 0;
    }


    bool isGrounded()
    {
        return Physics.Raycast(transform.position, Vector3.down, distToGround);
    }
}
