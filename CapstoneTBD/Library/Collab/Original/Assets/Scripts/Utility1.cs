using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility1 : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    Utility1Database database;

    //Jump variables
    public bool jumping;
    public int jumpCount = 0;
    public Transform groundCheck;
    public float groundCheckRadius;
    public LayerMask groundLayer;
    public bool onGround;
    public float jumpcd;

    //better jump variables
    public float fallMultiplier;
    public float lowJumpMultiplier;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Utility1Database>();
    }

    void Start()
    {
        groundCheckRadius = 0.01f;
        fallMultiplier = 2f;
        lowJumpMultiplier = 2f;
        jumpcd = -2f;
    }

    void Update()
    {
        //used to check if player is on ground
        onGround = Physics2D.OverlapCircle(groundCheck.position, stats.groundCheckRadius, groundLayer);
        if (onGround)
        {
            jumping = false;
            if (rb2d.velocity.y == 0) {
                jumpCount = 0;
            }
        }

        //Used for better jump
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        }
    }

    public void FixedUpdate()
    {
        
        if (Input.GetKey(KeyCode.F))
        {
            database.startTime -= Time.deltaTime;
            rb2d.AddForce(Vector2.up * database.JetPackForce);
        }
        if (database.startTime <= 0.0f)
        {
            database.startTime = 3.5f;
        }
        
    }

    public void utility()
    {
        //Note that the check for jumpcd will most likely have to be moved to specific
        //jump functions as more utility methods are added
        if (onGround && Time.time - jumpcd >= .1f)
        {
            jumpCount++;
            jumpcd = Time.time;
            //Switch statement for jumping based on utility
            switch (stats.utility1)
            {
                case 1:
                    database.jump();
                    jumping = true;
                    break;
                default:
                    database.jump();
                    jumping = true;
                    break;
            }
            
        }
        //Note that the check for jumpcd will most likely have to be moved to specific
        //jump functions as more utility methods are added
        else if (!onGround && Time.time - jumpcd >= .1f)
        {
            jumpcd = Time.time;
            //Switch statement for doing things in the air based on utility
            switch (stats.utility1)
            {
                case 4:
                    database.jetpack();
                    break;
                case 3:
                    database.jumpTeleport();
                    break;
                case 2:
                    database.airFloat();
                    break;
                case 1:
                    if (jumpCount < 2)
                    {
                        jumpCount++;
                        database.jump();
                        jumping = true;
                    }
                    break;
                default:
                    break;
            }
        }
    }

    public void reset()
    {
        switch (stats.utility1)
        {
            case 2:
                database.resetGravity();
                break;
            default:
                break;
        }
    }
}
