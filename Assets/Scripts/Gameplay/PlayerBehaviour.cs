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

    public bool pause;

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

    public GameObject textPause;

    public AudioSource deathSound;

    public bool isDead = false;
    public bool isTouching;

    public Animator anim;
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
        anim = FindObjectOfType<Animator>();
    }

    // Update is called once per frame
    void Update()
    {
        if(isDead) return;
        //Suelo.
        //grounded = Physics2D.IsTouchingLayers(col, whatIsGround);
        grounded = Physics2D.OverlapCircle(groundCheck.position, groundCheckRadius, whatIsGround);
        anim.SetBool("isGrounded", true);
        //Mecánica moverse

        if(transform.position.x >= speedMilestoneCount)
        {
            speedMilestoneCount += speedIncreaseMilestone;

            speedIncreaseMilestone = speedIncreaseMilestone * speedMultiplier;
            moveSpeed = moveSpeed * speedMultiplier;
        }

        rb.velocity = new Vector2(moveSpeed, rb.velocity.y);
        
        if(Input.GetButtonDown("Jump"))
        {
            if (grounded)
            {
                Debug.Log("Start jump");
                anim.SetTrigger("jump");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);        
                jumpTimeCounter = jumpTime;
                anim.SetBool("isGrounded", false);
            }
        }
        else if(Input.GetButton("Jump"))
        {
            if(!grounded && jumpTimeCounter > 0)
            {
                Debug.Log("Jumping");
                rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                jumpTimeCounter -= Time.deltaTime;
                anim.SetBool("isGrounded", false);
            }
       
        }
       

        if(Input.GetKeyUp(KeyCode.Space) || Input.GetMouseButtonUp(0))
        {
            jumpTimeCounter = 0;
        }

        //MOBILE INPUTS
       if (Input.touchCount > 0)
        {
            Touch touch = Input.GetTouch(0);

            switch (touch.phase)
            {
                //When a touch has first been detected
                case TouchPhase.Began:
                   
                    if (grounded)
                    {
                        rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                        jumpTimeCounter = jumpTime;
                    }
                    isTouching = true;
                    break;

                case TouchPhase.Stationary:
                    if (isTouching == true)
                    {
                        Debug.Log("Entra?");
                        if (jumpTimeCounter > 0)
                        {
                            rb.velocity = new Vector2(rb.velocity.x, jumpForce);
                            jumpTimeCounter -= Time.deltaTime;
                        }
                    }
                    break;

                case TouchPhase.Ended:
                    isTouching = false;
                    jumpTimeCounter = 0;
                    break;
            }
        }

        

        if(Input.GetKeyUp(KeyCode.P)) GameManager.PauseGame();
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if(other.gameObject.tag == "KillBox")
        {
            if(isDead == true) return;
            isDead = true;
            isTouching = false;
            moveSpeed = moveSpeedStore;
            speedMilestoneCount = speedMilestoneCountStore;
            speedIncreaseMilestone = speedIncreaseMilestoneStore;
            deathSound.Play();
            GameManager.PlayerDie();

            rb.velocity = Vector2.zero;
            rb.AddForce(Vector2.up * 2, ForceMode2D.Impulse);
        }
    }
}
