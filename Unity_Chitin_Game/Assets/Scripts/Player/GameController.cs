using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameController : MonoBehaviour {

    public bool timeElapsed = false;
    public int playerCount;             // need to add: decrease when a player dies     


	void Start()
    {
        GameObject[] playerList = GameObject.FindGameObjectsWithTag("Player") as GameObject[];
        playerCount = playerList.Length;
        // need to know when playerCount = 1, then handle game over
    }
	
	void Update()
    {
        if (playerCount == 0)
        {
            BroadcastMessage("You Win!");
            //end round, award "last bug standing" bonus
        }
        if (timeElapsed)
        {
            BroadcastMessage("You Win!");
            //end round, award "survivor" bonus
        }
    }


    void timeHasElapsed()
    {
        timeElapsed = true; 
        //handle game over
    }

}
