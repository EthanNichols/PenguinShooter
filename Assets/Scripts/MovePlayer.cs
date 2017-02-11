using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    //Speed of the X movement speed
    //The maximum X movement speed
    //The height the player jumps
    //The amount of friction while on the ground
    //The amount of gravity when jumping
    public float speed;
    public float maxSpeed;
    public float jumpHeight;
    public float friction;
    public float gravity;

    //The movement (velocity) of the player
    private Vector2 movement;

    //The state that the player is in
    private playerState state = playerState.standing;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //Check if the player is testing and pressed the jump button
        //Make the player jump and change the state of the player to jumping
        if (state == playerState.standing && Input.GetKey(KeyCode.Space))
        {
            movement = new Vector2(0, jumpHeight);
            state = playerState.jumping;
        }

        //Test if the player state is jumping
        //Make the player fall
        //Else make the player slower on the ground
        if (state == playerState.jumping)
        {
            playerFall();
        } else
        {
            playerFriction();
        }

        //Test for inputs for the player
        //Test if the player is going faster than maximum speed
        //Move the player relative to the movement
        playerInput();
        maximumSpeed();
        playerMove();
    }

    private void playerInput()
    {
        //Test for the 'A' key
        //Move the player to the left
        if (Input.GetKey("a"))
        {
            movement.x -= speed;

        //Test for the 'D' key
        //Move the player to the right
        }
        else if (Input.GetKey("d"))
        {
            movement.x += speed;
        }
    }

    private void playerMove()
    {
        //Move the player relative to the movement vector
        transform.Translate(movement * Time.deltaTime);
    }

    private void playerFall()
    {
        //Make the player fall relative to the gravity modifier
        movement.y -= gravity * Time.deltaTime;
    }

    private void playerFriction()
    {
        //Test if the player is going significantly slow
        //Set the X speed to 0
        if (movement.x < 1 &&
        movement.x > 1)
        {
            movement.x = 0;
        }

        //Cut the speed of the player by the friction of the platform
        movement.x /= friction;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        //Set that the play is standing
        //Make the player stop falling and stay on the platform
        state = playerState.standing;
        movement = new Vector2(movement.x, 0);
    }

    private void maximumSpeed()
    {
        //Test if the player is going faster than the maximum speed
        //Set the player speed to the max in the relative direction
        if (movement.x < -maxSpeed)
        {
            movement.x = -maxSpeed;
        }

        if (movement.x > maxSpeed)
        {
            movement.x = maxSpeed;
        }
    }

    //Player states
    private enum playerState
    {
        standing,
        jumping
    }
}
