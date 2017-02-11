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

    private bool left = false;

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

        if (Input.GetKey(KeyCode.A))
        {
            left = true;
        } else if (Input.GetKey(KeyCode.D))
        {
            left = false;
        }
    }
    void fireRocket()
    {
        if (Time.time > nextFire)
        {
            //removes next once facing direction is implemented
            nextFire = Time.time + fireRate;
            //needs to add method detecting if it is facing right or left

            //added for facing direction
            if (left)
            {
                Instantiate(bullet, new Vector3(gunTip.position.x - 1, gunTip.position.y), Quaternion.Euler(new Vector3(0, 0, 180)));
            }

            else if (!left)
            {
                Instantiate(bullet, gunTip.position, Quaternion.Euler(new Vector3(0, 0, 0)));
            }
        }
    }
}
