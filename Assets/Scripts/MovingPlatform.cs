using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovingPlatform : MonoBehaviour {

    private Vector3 positionA;
    private Vector3 positionB;
    private Vector3 nextPosition;

    [SerializeField]
    private Transform childTransform;
    [SerializeField]
    private Transform transformB;
    [SerializeField]
    private float speed;
	// Use this for initialization
	void Start () {
        positionA = childTransform.localPosition;
        positionB = transformB.localPosition;
        nextPosition = positionB;
	}
	
	// Update is called once per frame
	void Update () {
        Move();
        
	}
    private void Move()
    {
        childTransform.localPosition = Vector3.MoveTowards(childTransform.localPosition, nextPosition, speed*Time.deltaTime);
        
        if (Vector3.Distance(childTransform.localPosition,nextPosition) <= 0.1)
        {
            ChangeDestination();
        }
        
    }
    private void ChangeDestination()
    {
        nextPosition = nextPosition != positionA ? positionA : positionB;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "Player")
        {
            other.transform.parent = childTransform;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        other.transform.SetParent(null);
    }
}
