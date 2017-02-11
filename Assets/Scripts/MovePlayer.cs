using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float speed;
    public float maxSpeed;
    public float jumpHeight;
    public float friction;
    public float gravity;

    private Vector2 movement;

    private playerState state = playerState.standing;

    void Start()
    {

    }

    void FixedUpdate()
    {
        if (state == playerState.standing && Input.GetKey(KeyCode.Space))
        {
            movement = new Vector2(0, jumpHeight);
            state = playerState.jumping;
        }
        if (state == playerState.jumping)
        {
            playerFall();
        } else
        {
            playerFriction();
        }

        playerInput();
        maximumSpeed();

        playerMove();
    }

    private void playerInput()
    {
        if (Input.GetKey("a"))
        {
            movement.x -= speed;
        } else if (Input.GetKey("d"))
        {
            movement.x += speed;
        }
    }

    private void playerMove()
    {
        transform.Translate(movement * Time.deltaTime);
    }

    private void playerFall()
    {
        movement.y -= gravity * Time.deltaTime;
    }

    private void playerFriction()
    {
        if (movement.x < 1 &&
        movement.x > 1)
        {
            movement.x = 0;
        }

        movement.x /= friction;
    }

    private void OnCollisionEnter2D(Collision2D col)
    {
        state = playerState.standing;
        movement = new Vector2(movement.x, 0);
    }

    private void maximumSpeed()
    {
        if (movement.x < -maxSpeed)
        {
            movement.x = -maxSpeed;
        }

        if (movement.x > maxSpeed)
        {
            movement.x = maxSpeed;
        }
    }

    private enum playerState
    {
        standing,
        jumping
    }
}
