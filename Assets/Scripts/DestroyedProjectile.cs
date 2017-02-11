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
    void OnCollisionEnter2D()
    {
       Debug.Log("Collision");


        Invoke("destroyProjectile", .1f);
    }
    void destroyProjectile()
    {
        Destroy(gameObject);
    }
    
    
      
    }

