using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovePlayer : MonoBehaviour {

    public float speed;
    public float friction;
    public float jump;

    public Vector3 movement;
    private bool jumping = false;

    Dictionary<KeyCode, Vector3> moves = new Dictionary<KeyCode, Vector3>();

	// Use this for initialization
	void Start () {
        moves.Add(KeyCode.A, new Vector3(-1, 0));
        moves.Add(KeyCode.D, new Vector3(1, 0));
    }
	
	// Update is called once per frame
	void Update () {
        testMovement();
        slowDown();
        move();
	}

    private void testMovement()
    {

        if (Input.GetKeyDown(KeyCode.Space) && !jumping)
        {
            movement += new Vector3(movement.x, jump, 0);
            jumping = true;
        }

        foreach (KeyValuePair<KeyCode, Vector3> move in moves)
        { 
            if (Input.GetKey(move.Key))
            {
                movement += (move.Value * speed) * Time.deltaTime;
            }
        }
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject)
        {
            jumping = false;
        }
    }

    private void slowDown()
    {
        movement = movement / friction;

        if (jumping)
        {
            movement -= new Vector3(0, 1);
        }
    }

    private void move()
    {
        transform.position += movement * Time.deltaTime;
    }
}
