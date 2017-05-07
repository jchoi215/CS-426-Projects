using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Score : MonoBehaviour {

    private int playerScore = 0;

    public void addPoints(int pointAwarded)
    {
        playerScore += pointAwarded;
    }

    public int getPoint()
    {
        return playerScore;
    }
}
