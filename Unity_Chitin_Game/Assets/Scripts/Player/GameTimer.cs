using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameTimer : MonoBehaviour {

    public int timeRemaining = 600;     // 10 minute rounds
    public UnityEngine.UI.Text timer;

    void Start()
    {
        InvokeRepeating("decreaseTimeRemaining", 1, 1);
	}
	
	void Update()
    {
		if (timeRemaining == 0)
        {
            SendMessageUpwards("timeHasElapsed");
            CancelInvoke("decreaseTimeRemaining");
        }

        timer.text = formatTime(timeRemaining);
	}


    void decreaseTimeRemaining()
    {
        timeRemaining--;
    }

    string formatTime(int seconds)
    {
        int minutes = 0;
        for (; seconds > 60; seconds -= 60) { minutes++; }
        return minutes + " : " + seconds;
    }
}
