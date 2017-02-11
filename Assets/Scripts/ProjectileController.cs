using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ProjectileController : MonoBehaviour {


    Rigidbody2D projectileRB;
    public float rocketSpeed;
  
    

	// Use this for initialization
	void Awake ()
    {
        //allows reference to rigidbody
        projectileRB = GetComponent<Rigidbody2D>();
        

        //travels in x direction only
        projectileRB.AddForce(new Vector2(1, 0) * rocketSpeed,ForceMode2D.Impulse);
       

	}
	
	// Update is called once per frame
	void Update ()
    {
		
	}
  
}
