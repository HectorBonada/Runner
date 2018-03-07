using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public float moveSpeed;
    public float speedMultiplier; //Aumentar velocidad respecto al tiempo.

    public float speedIncreaseMilestone;
    private float speedMilestoneCount;
    private float speedMilestoneCountStore;
    private float moveSpeedStore;
    public float speedIncreaseMilestoneStore;
    public float jumpForce;
    public bool die = false;

    public float jumpTime;
    private float jumpTimeCounter;

    private Rigidbody2D rb;

    public bool grounded;
    public LayerMask whatIsGround;
    public Transform groundCheck;
    public float groundCheckRadius;

    public float force;

    private Collider2D col;

    public GameManager GameManager;

    public GameObject canvasEnd;

    // Use this for initialization
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        col = GetComponent<Collider2D>();
        rb.gravityScale = force;
        jumpTimeCounter = jumpTime;
        speedMilestoneCount = speedIncreaseMilestone;
        moveSpeedStore = moveSpeed;
        speedMilestoneCountStore = speedMilestoneCount;
        speedIncreaseMilestoneStore = speedIncreaseMilestone;
    }

    // Update is called once per frame
    void Update()
    {
        if(die == false)
        {
            //Suelo.
            //grounded = Physics2D.IsTouchingLayers(col, whatIsGround);
            grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);

            //Mecánica moverse

            if(transform.position.x >= speedMilestoneCount)
            {
                speedMilestoneCount += speedIncreaseMilestone;

                speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
                moveSpeed = moveSpeed * speedMultiplier;
            }

            rb.velocity = new Vector2(moveSpeed, rb.velocity.y);

            if(Input.GetKeyDown(KeyCode.Space) || Input.GetMouseButtonDown(0))
            {
                if(grounded)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                }
            }

            if(Input.GetKey(KeyCode.Space) || Input.GetMouseButton(0))
            {
                if(jumpTimeCounter > 0)
                {
                    rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                    jumpTimeCounter -= Time.deltaTime;
                }
            }

            if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
            {
                jumpTimeCounter = 0;
            }

            if(grounded)
            {
                jumpTimeCounter = jumpTime;
            }
        }
        if (die == true)
        {
            if(Input.GetKeyDown(KeyCode.R))
            {
                GameManager.RestartGame();
                die = false;
            }
        }
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "KillBox")
        {
            StartCoroutine("YouDie");
            die = true;
            //canvasEnd.SetActive(true);
            //GameManager.RestartGame();
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
        }
    }

    public IEnumerator YouDie()
    {
        yield return new WaitForSeconds(0.5f);
        canvasEnd.SetActive(true);
    }

}
