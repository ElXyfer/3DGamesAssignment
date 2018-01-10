using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    ///public float PlayerHealth;
    /// 

    public float speed;
    public float runningSpeed;
    public float fastSwimmingSpeed;
    public float rotationSpeed = 100.0f;
    float swimSpeed = 2;
    public bool isMoving = false;
    public bool isSwimming = false;
    bool canMove;
    float distToGround = 0.75f;
    public GameObject sceneManager;

    Animator anim;
    FloatingScript floatingScript;
    Inventory inventory;
    PlayerHealth playerHealth;
    MySceneManager mySceneManager;



    bool logBox;

    // Use this for initialization
    void Awake () {
        anim = GetComponent<Animator>();
        inventory = GetComponent<Inventory>();
        playerHealth = GetComponent<PlayerHealth>();
        floatingScript = GetComponent<FloatingScript>();
        mySceneManager = sceneManager.GetComponent<MySceneManager>();
        floatingScript.enabled = false;
        canMove = true;
    }
    
    // Update is called once per frame
    void Update () {
        
        //if(dialogueSystem.DialogBoxIsShowing == true) {
        //    canMove = false;
        //} else {
        //    canMove = true;
        //}
        //if(canMove == false) {
        //    anim.SetBool("isIdle", true);
        //    anim.SetBool("isSwimming", false);
        //    anim.SetBool("isWalking", false);
        //    anim.SetBool("isRunning", false);
        //    anim.SetBool("isAttacking", false);
        //    return;
        //} 

       
        if (Input.GetKeyDown("space")){
            anim.SetBool("isAttacking", true);
//            anim.SetBool("isWalking", false);
//            anim.SetBool("isRunning", false);
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
            isMoving = false;
        }


    }

    void OnTriggerEnter(Collider hC)
    {
        if (hC.gameObject.tag == "heightChecker" && !isGrounded())
        {
            print("Dead");
            anim.SetBool("isFalling", true);
            anim.SetBool("isIdle", false);
            anim.SetBool("isRunning", false);
            anim.SetBool("isAttacking", false);
            anim.SetBool("isSwimming", false);
            anim.SetBool("isWalking", false);

            playerHealth.Death();

        }

        //if (hC.gameObject.tag == "Water")
        //{
        //    isSwimming = true;
        //}


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
        anim.SetBool("isFalling", false);

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
        anim.SetBool("isFalling", false);

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
