using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMove : MonoBehaviour
{
    public float moveSpeed = 5f;
    private float currentSpeed;

    private Rigidbody rb;
    public bool movable = true;
    public bool isMoving = false;
    public bool isThrowing = false;
    private Vector3 movement;

    public AudioSource audioSource;

    public Transform up;
    public Transform right;
    public Transform left;
    public Transform down;
    public Transform uRight;
    public Transform uLeft;
    public Transform dRight;
    public Transform dLeft;
    public float turnSpeed = 2f;
    private Vector3 turnMeasure;
    private float turnStep;

    public Transform rotateCharacter;
    // Start is called before the first frame update
    void Start()
    {
        movement.y = 0;
        rb = gameObject.GetComponent<Rigidbody>();
    }

    // Update is called once per frame
    void Update()
    {

        //Getting Player movement input
        if (movable)
        {
            movement.x = Input.GetAxisRaw("Horizontal"); //get Horizontal and vertical input
            movement.z = Input.GetAxisRaw("Vertical");
            movement = movement.normalized;
            //tempMovement = movement; //Stores movement for next update calculations
        }
        else
        {
            movement.x = 0;
            movement.y = 0;
            movement.z = 0;
        }

        turnMeasure = new Vector3 (Mathf.Abs(movement.x), Mathf.Abs(movement.y), Mathf.Abs(movement.z)); //Get the strength of input horizontal vs vertical

          if (movement.x !=0 || movement.z != 0)
        {
            isMoving = true;
        }
          else
        {
            isMoving = false;
        }

        
        if (isMoving && !isThrowing) //Only turn if moving, don't turn if currently throwing.
        {

            turnStep = turnSpeed * Time.deltaTime;
            //turnStep = 180f;
            //Debug.Log (turnStep);

            if (turnMeasure.z > turnMeasure.x)  //Check if there is more vertical direction than horizontal direction
            {
                //Debug.Log ("Vertical movement recorded");
                if (movement.z > 0) //Player is moving mostly up
                {
                    
                    rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, up.rotation, turnStep);

                }
                else
                {
                    rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, down.rotation, turnStep);
                }
            }
            else if (turnMeasure.z < turnMeasure.x) //Horizontal more than vertical
            {
                
                if (movement.x > 0) //Player is moving mostly right
                {
                    rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, right.rotation, turnStep);

                }
                else
                {
                    rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, left.rotation, turnStep);
                }
            }
            else //Player is going diagonal
            {

                if (movement.z > 0) //Player is moving up
                {
                    if (movement.x > 0) //Player is moving right
                    {
                        rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, uRight.rotation, turnStep);
                    }
                    else
                    {
                        rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, uLeft.rotation, turnStep);
                    }
                }
                else //Player is moving down
                {
                    if (movement.x > 0) //Player is moving right
                    {
                        rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, dRight.rotation, turnStep);
                    }
                    else
                    {
                        rotateCharacter.rotation = Quaternion.RotateTowards(rotateCharacter.rotation, dLeft.rotation, turnStep);
                    }
                }
            }
        }


    }


     private void FixedUpdate() 
    {
        if (movable)
        {
            
            rb.MovePosition(rb.position + movement * moveSpeed * Time.fixedDeltaTime); // take most recent movement direction and move that way
           
            

           
            
        }
    }
}
