using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Platform : MonoBehaviour {
    private BoxCollider2D playerCollider;
    [SerializeField]
    private BoxCollider2D platformTrigger;

    [SerializeField]
    private BoxCollider2D platformCollider;
	// Use this for initialization
	void Start () {
        playerCollider = GameObject.Find("Player").GetComponent<BoxCollider2D>();
        Physics2D.IgnoreCollision(platformCollider, platformTrigger,true);

	}
	
	// Update is called once per frame
	void Update () {
		
	}

   
}
