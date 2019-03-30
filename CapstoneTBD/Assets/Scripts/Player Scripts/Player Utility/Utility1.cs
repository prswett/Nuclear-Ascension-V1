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
    public bool onGround;
    public float jumpcd;
    public float teleportCount; //counts how many times you teleported


    //better jump variables
    public float fallMultiplier;
    public float lowJumpMultiplier;

    public bool airFloatActivate;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Utility1Database>();
    }

    void Start()
    {
        fallMultiplier = 2f;
        lowJumpMultiplier = 2f;
        jumpcd = -2f;
        teleportCount = 0;
        airFloatActivate = false;
    }

    void Update()
    {
        //used to check if player is on ground
        if (onGround)
        {
            jumping = false;
            if (rb2d.velocity.y == 0)
            {
                jumpCount = 0;
            }
        }

        //Used for better jump
        if (rb2d.velocity.y < 0)
        {
            rb2d.velocity += Vector2.up * Physics2D.gravity.y * (fallMultiplier - 1) * Time.deltaTime;
        }
        //else if (rb2d.velocity.y > 0 && !Input.GetKey(KeyCode.Space))
        //{
        //rb2d.velocity += Vector2.up * Physics2D.gravity.y * (lowJumpMultiplier - 1) * Time.deltaTime;
        //}

        //Terminal velocity
        if (rb2d.velocity.y > 5)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 5);
        }
        else if (rb2d.velocity.y < -5)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, -5);
        }
    }

    public void utilityMovementTool()
    {
        switch (stats.utility1)
        {
            case 3:
                database.jetpack();
                break;
            case 1:
                if (airFloatActivate)
                {
                    database.airFloat();
                }
                break;
            default:
                break;
        }
    }

    public void utility()
    {
        //Note that the check for jumpcd will most likely have to be moved to specific
        //jump functions as more utility methods are added
        if (onGround && Time.time - jumpcd >= .1f)
        {
            teleportCount = 0;
            jumpcd = Time.time;
            //Switch statement for jumping based on utility
            switch (stats.utility1)
            {
                case 3:
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
                case 3:
                    break;
                case 2:
                    if (jumpCount < 1 && teleportCount == 0)
                    {
                        database.jumpTeleport();
                        teleportCount++;
                        break;
                    }
                    break;
                case 1:
                    airFloatActivate = true;
                    break;
                default:
                    if (jumpCount < 1)
                    {
                        jumpCount++;
                        database.doubleJump();
                        jumping = true;
                    }
                    break;
            }
        }
    }

    public void jumpReset()
    {
        switch (stats.utility1)
        {
            case 3:
                database.resetJetPack();
                break;
            case 2:
                database.resetGravity();
                break;
            case 1:
                airFloatActivate = false;
                database.resetGravity();
                break;
            default:
                break;
        }
    }
}
