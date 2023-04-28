using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ThirdPersonMovement : MonoBehaviour
{
    public CharacterController controller;
    public Transform cam;
    public BoxCollider box;
    public FollowPlayer fp;
    public float topSpeed = 20f;
    public float jumpHeight = 20f;

    bool isGrounded = false; // I made my own isGrounded variable because controller.isGrounded is a little tricky
    float accelMult = 0.2f;
    float horizontal, vertical;
    float verticalVelocity = 0f;
    int jumpCount = 10;
    Vector3 direction;
    Vector3 gravityVector;
    Vector3 momentum = Vector3.zero;

    // Function to help make debugging a little easier
    void p(object s){
        Debug.Log(s);
    }

    // Update is called once per frame
    void Update()
    {
        horizontal = Input.GetAxisRaw("Horizontal");
        vertical = Input.GetAxisRaw("Vertical");
        direction = new Vector3(horizontal, 0f, vertical).normalized; // determine direction
        direction = Quaternion.Euler(0, cam.eulerAngles.y, 0) * direction; // rotates direction to fit with the camera orientation
        
        // if the player is grounded and the user is pressing the space key, the player will jump
        if(Input.GetKey("space") && isGrounded){
            verticalVelocity = jumpHeight;
            isGrounded = false;
            jumpCount = 10; // will be explained below
        }
        /* I made it so isGrounded would switch to true as soon as the player lands and controller.isGrounded switches to true,
        But since controller.isGrounded switches to true for a few frames after the player jumps, isGrounded would remain true
        Therefore I made a counter that would stop that from happening*/
        if(jumpCount > 0){
            jumpCount--;
        }
        if(controller.isGrounded && jumpCount==0){
            isGrounded = true;
        }

        // If the player is airborne, their ability to control their movement is less
        if(isGrounded){
            accelMult = 0.5f;
        } else {
            accelMult = 0.03f;
        }

        //If the user inputs a direction
        if(direction.magnitude >= 0.01f){

            /*This builds momentum in the direction of the user's input and multiplies it 
            by the acceleration multiplier that depends on whether the player is grounded or not*/
            momentum = momentum + (direction * accelMult);
            if(momentum.magnitude > topSpeed){// This keeps the player from moving faster than the top speed
                momentum = momentum.normalized * topSpeed;
            }
            transform.LookAt(momentum + transform.position); //This rotates the player to be facing the direction of its momentum

        } else {
            /* when the user is not inputting a direction, 
            the players momentum is slowed by adding an opposing force at a constant rate */
            momentum = momentum - (momentum.normalized * accelMult);
        }

        controller.Move(momentum * Time.deltaTime); //The player is moved

        
        /* Gravity functionality, if the player is grounded, the downward vertical velocity is constant.
        Otherwise, the downward vertical velocity increases at a constant rate */
        gravityVector = Vector3.zero;
        if (controller.isGrounded){
            verticalVelocity = -0.1f;
        } else {
            verticalVelocity -= 0.1f;
        }
        gravityVector += new Vector3(0,verticalVelocity,0);

        controller.Move(gravityVector * Time.deltaTime);

    }
}
