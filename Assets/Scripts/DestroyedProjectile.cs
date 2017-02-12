using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DestroyedProjectile : MonoBehaviour {

    public float aliveTime;

	// Use this for initialization
   
	void Awake ()
    {
        Destroy(gameObject, aliveTime);
	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
    void OnCollisionEnter2D(Collision2D col)
    {
       Debug.Log("Collision");

        if (col.gameObject.GetComponent<MovePlayer>().playerNum != GetComponent<ProjectileController>().player)
        {
            Invoke("destroyProjectile", .1f);
        }
    }
    void destroyProjectile()
    {
        Destroy(gameObject);
    }
    
    
      
    }

