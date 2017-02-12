using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawner : MonoBehaviour {

    public Transform start;
    public GameObject Enemy;
    float rateOfSpawn=.5f;
    float currentSpawn = 0f;
    bool spawning = true;

	// Use this for initialization
	void Start ()
    {
        SpawnEnemy();
	}
	
	// Update is called once per frame
	void Update () {
        if (Time.time > currentSpawn)
        {
            Instantiate(Enemy, start.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            currentSpawn = Time.time + rateOfSpawn;
        }

    }
    void SpawnEnemy()
    {
        if (Time.time > currentSpawn)
        {
            Instantiate(Enemy, start.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            currentSpawn = Time.time + rateOfSpawn;
        }
    }
}
