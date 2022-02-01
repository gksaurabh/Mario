using System.Collections;
using UnityEngine.UI;
using System.Collections.Generic;
using UnityEngine;

public class ScoreManager : MonoBehaviour {
    private Text myText;
    public static int playerScore;

	// Use this for initialization
	void Start () {
        myText = GetComponent<Text>();
        playerScore = 0;
	}
	
	// Update is called once per frame
	void Update () {
        myText.text = "Score: " + playerScore;
	}
}
