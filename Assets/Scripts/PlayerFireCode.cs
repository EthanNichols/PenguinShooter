using System.Collections;
using System.Collections.Generic;
using UnityEngine;
//Chase Slattery1
public class PlayerFireCode : MonoBehaviour
{

    //for shooting
    public Transform gunTip;
    public GameObject bullet;
    float fireRate = .5f;
    float nextFire = 0f;
    // Use this for initialization
    void Start()
    {


    }

    // Update is called once per frame
    void Update()
    {
        //player shooting
        if (Input.GetKeyDown(KeyCode.Q))
        {
            fireRocket();
        }
    }
    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            //removes next once facing direction is implemented
            Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            nextFire = Time.time + fireRate;
            //needs to add method detecting if it is facing right or left

            //added for facing direction
            //if(facingRight){
            /*Instantiate(bullet, gunTip.position, Quaternian.Euler(new Vector3 (0,0,0)));
             * }
             * 
             * else if(!facingright){
             * Instnatiate(bullet, guntip.Position, Quernion.Euler(new Vector3 (0,0,180f)));
             **/
        }
    }
}
