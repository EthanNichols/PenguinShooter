using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FishMovement : MonoBehaviour {

    public int direction;
    public int despawn;
    public float timer;

    private int speed;

    // Use this for initialization
    void Start () {
        speed = Random.Range(2, 5);
	}
	
	// Update is called once per frame
	void Update () {
        transform.position += new Vector3(speed, Mathf.Cos(transform.position.x / speed)) * direction * Time.deltaTime;

        timer += Time.deltaTime;

        if (timer > despawn)
        {
            Destroy(gameObject);
        }
	}

    void OnCollisionEnter2D(Collision2D col)
    {
        int player = col.gameObject.GetComponent<ProjectileController>().player;

        if (player == 1)
        {
            GetComponentInParent<GameManager>().player1Collected++;
            Destroy(gameObject);
        } else if (player == 2)
        {
            GetComponentInParent<GameManager>().player2Collected++;
            Destroy(gameObject);
        }
    }
}
