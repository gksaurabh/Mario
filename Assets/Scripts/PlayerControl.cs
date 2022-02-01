using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControl : MonoBehaviour {

    private Rigidbody2D myRigidBody2D;
    private Animator myAnimator;
    public float horizontal;
    private bool faceForeward;

    [SerializeField]
    private Transform[] groundPoints;    

    [SerializeField]
    private float groundRadius;

    [SerializeField]
    private LayerMask whatIsGround;

    private bool bGrounded;
    private bool bJump;

    [SerializeField]
    private bool bAirControl;
    [SerializeField]
    private float jumpForce;

    [SerializeField]
    private float playerSpeed;
	// Use this for initialization
	void Start ()
    {
        faceForeward = true;
        myRigidBody2D = GetComponent<Rigidbody2D>();
        myAnimator = GetComponent<Animator>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        inputHandle();
        
	}

    private void FixedUpdate()
    {
        horizontal = Input.GetAxis("Horizontal");
        bGrounded = isGrounded();
        handleMovement(horizontal);
        resetValues();
        flip(horizontal);
    }
    void handleMovement(float horizontal)
    {
       if (bGrounded || bAirControl)
       {
            myRigidBody2D.velocity = new Vector2(horizontal * playerSpeed, myRigidBody2D.velocity.y);
            myAnimator.SetFloat("speed", Mathf.Abs(horizontal));
       }
        if (bGrounded && bJump)
        {
            bGrounded = false;
            myRigidBody2D.AddForce(new Vector2(0, jumpForce));
          
        }
    }

    private void inputHandle()
    {
        if (Input.GetKeyDown(KeyCode.UpArrow) || Input.GetKeyDown(KeyCode.Space))
        {
            bJump = true;
        }
    }
    private void flip(float horizontal)
    {
       if (horizontal > 0 && !faceForeward || horizontal <0 && faceForeward)
        {
            faceForeward = !faceForeward;

            Vector3 theScale = transform.localScale;
            theScale.x *= -1;
            transform.localScale = theScale;
        }
      
    }

    private bool isGrounded()
    {
        if (myRigidBody2D.velocity.y <= 0)
        {
            foreach(Transform point in groundPoints)
            {
                Collider2D[] colliders = Physics2D.OverlapCircleAll(point.position, groundRadius, whatIsGround);

                for(int iCounter = 0; iCounter < colliders.Length; iCounter++)
                {
                    if (colliders[iCounter].gameObject != gameObject)
                    {
                        return true;
                    }
                }
            }
        }
        return false;
    }
    private void resetValues()
    {
        bJump = false;
    }

}
