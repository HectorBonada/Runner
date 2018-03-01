using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour {
    public float moveSpeed;
    public float jumpForce;
    private Rigidbody2D rb;

    public bool grounded;
    public LayerMask whatIsGround;

    private Collider2D col;
	// Use this for initialization
	void Start ()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
	}
	
	// Update is called once per frame
	void Update ()
    {
        //Suelo.
        grounded = Physics2D.IsTouchingLayers(col, whatIsGround);

        //Mecánica moverse
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if (Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(2))
        {
            if (grounded)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
            }
        }
	}
}
