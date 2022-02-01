using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour {
    private BoxCollider2D myBoxCollider2D;
    private int coinValue = 100;
    private object Project;

    // Use this for initialization
    void Start ()
    {
        myBoxCollider2D = gameObject.GetComponent<BoxCollider2D>();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

    private void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.gameObject.name == "Player")
        {
            ScoreManager.playerScore += coinValue;
            Destroy(gameObject);
        }
      
    }
}
