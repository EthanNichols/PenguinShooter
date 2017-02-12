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

    public int playerNum;
    public KeyCode Ileft;
    public KeyCode Iright;
    public KeyCode Ijump;
    public KeyCode Ifire;

    public Transform gunTip;
    public GameObject bullet;

    private float fireRate = .5f;
    private float nextFire = 0f;

    //The movement (velocity) of the player
    private Vector2 movement;
    private bool left;
    private float respawnTimer;

    //The state that the player is in
    private playerState state = playerState.standing;

    void Start()
    {

    }

    void FixedUpdate()
    {
        //Check if the player is testing and pressed the jump button
        //Make the player jump and change the state of the player to jumping
        if (state != playerState.jumping && Input.GetKey(Ijump))
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
        respawn();
    }

    private void playerInput()
    {
        //Test for the 'A' key
        //Move the player to the left
        if (Input.GetKey(Ileft))
        {
            movement.x -= speed;
            left = true;

        //Test for the 'D' key
        //Move the player to the right
        }
        else if (Input.GetKey(Iright))
        {
            movement.x += speed;
            left = false;
        }

        if (Input.GetKey(Ifire))
        {
            fireArrow();
        }
        nextFire += Time.deltaTime;
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

    private void respawn()
    {
        if (respawnTimer > 0)
        {
            respawnTimer -= Time.deltaTime;
        }

        if (respawnTimer < 0)
        {
            respawnTimer = 0;
            transform.position = new Vector3(0, 0);
        }
    }

    private void fireArrow()
    {
        if (fireRate < nextFire)
        {
            if (left)
            {
                GameObject arrow = Instantiate(bullet, new Vector3(transform.position.x - 1.4f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, 180)));
                arrow.GetComponent<ProjectileController>().rocketSpeed *= -1;
                arrow.GetComponent<ProjectileController>().player = playerNum;
            }

            else if (!left)
            {
                GameObject arrow = Instantiate(bullet, new Vector3(transform.position.x + 1.4f, transform.position.y), Quaternion.Euler(new Vector3(0, 0, 0)));
                arrow.GetComponent<ProjectileController>().player = playerNum;
            }

            nextFire = 0;
        }
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
        movement = new Vector2(movement.x * (friction * 2), 0);

        if (col.transform.tag == "Arrow" && col.gameObject.GetComponent<ProjectileController>().player != playerNum && respawnTimer == 0)
        {
            transform.position = new Vector3(-1000, 0);
            respawnTimer = 3;

            if (col.gameObject.GetComponent<ProjectileController>().player == 1)
            {
                GetComponentInParent<GameManager>().player1Collected = 0;
                GetComponentInParent<GameManager>().CollectScore(2);
            } else if (col.gameObject.GetComponent<ProjectileController>().player == 2)
            {
                GetComponentInParent<GameManager>().player2Collected = 0;
                GetComponentInParent<GameManager>().CollectScore(1);
            }
        }
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
