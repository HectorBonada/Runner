using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float jumpForce;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D rb;

    public bool grounded;
    public LayerMask whatIsGround;

    public float force;

    private Collider2D col;
    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.gravityScale = force;
        jumpTimeCounter = jumpTime;
    }

    // Update is called once per frame
    void Update()
    {
        //Suelo.
        grounded = Physics2D.IsTouchingLayers(col, whatIsGround);
        force = 1f;
        rb.gravityScale = force;
        //Mecánica moverse
        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

        if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
        {
            if(grounded)
            {
               
            }
        }

        if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
        {
            if (jumpTimeCounter > 0)
            {
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
            }
        }
       
        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        if (grounded)
        {
            jumpTimeCounter = jumpTime;
        }
    }
}
