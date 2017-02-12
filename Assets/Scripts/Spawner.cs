using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform start;
    public GameObject Enemy;
    public int spawnDirection;
    public GameObject parent;

    private float rateOfSpawn=.5f;
    private float currentSpawn = 0f;
    private int moveDirection;
    private int speed;

	// Use this for initialization
	void Start ()
    {
        int direction = Random.Range(0, 2);

        if (direction == 0)
        {
            moveDirection = -1;
        }
        else
        {
            moveDirection = 1;
        }

        speed = Random.Range(1, 5);
	}
	
	// Update is called once per frame
	void Update () {
        if (currentSpawn > rateOfSpawn)
        {
            GameObject fish = Instantiate(Enemy, start.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            fish.GetComponent<FishMovement>().direction = spawnDirection;
            fish.transform.SetParent(parent.transform);

            if(spawnDirection == 1)
            {
                fish.GetComponent<SpriteRenderer>().flipX = true;
            }

            currentSpawn = 0;
            rateOfSpawn = Random.Range(5, 10);
        }

        currentSpawn += Time.deltaTime;

        if (transform.position.y > 13 ||
        transform.position.y < -4)
        {
            moveDirection *= -1;
        }

        transform.position += new Vector3(0, speed * moveDirection) * Time.deltaTime;
    }
}
