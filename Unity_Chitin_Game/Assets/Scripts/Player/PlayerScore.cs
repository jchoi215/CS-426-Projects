using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerScore : MonoBehaviour {

    public int score;
    public UnityEngine.UI.Text scoreUI;

    // Use this for initialization
    void Start() {
        score = 0;
        scoreUI.text = score + "";
    }

    // Update is called once per frame
    void Update() {

    }

    public void updateScore()
    {
        scoreUI.text = (++score) + "";
    }

}
