using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Manager : MonoBehaviour {
    private states state;

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
        if (state == states.playGame)
        {
            
        }

        else if (state == states.MainMenu)
        {

        }
        else if (state == states.Exit)
        {
            return;
        }
		
	}
    enum  states
    {
        playGame,
        MainMenu,
        Exit
    }
}
