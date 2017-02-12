using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class GameManager : MonoBehaviour {

    public int player1Collected;
    public int player1Score;
    public int player2Collected;
    public int player2Score;

    public Text player1Info;
    public Text player2Info;

	// Use this for initialization
	void Start () {
        player1Collected = 0;
        player1Score = 0;
        player2Collected = 0;
        player2Score = 0;
	}
	
	// Update is called once per frame
	void Update () {
        player1Info.text = "Player 1:\nCollected Score: " + player1Collected + "\nTotal Score: " + player1Score;
        player2Info.text = "Player 2:\nCollected Score: " + player2Collected + "\nTotal Score: " + player2Score;

        player1Score++;
    }
}
