using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility1Database : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    public bool reset = false;
    //Used for teleport
    TeleportTarget teleport;
    public int staminaAmount;
    public bool staminaChange;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        teleport = stats.teleportCheck.GetComponent<TeleportTarget>();
    }
    void Start()
    {
        staminaAmount = stats.staminaRechargeAmount;
        staminaChange = false;
    }
    public void jump()
    {
        rb2d.velocity = Vector2.up * stats.jumpSpeed;
    }

    public void doubleJump()
    {
        if (stats.stamina >= 10)
        {
            rb2d.velocity = Vector2.up * stats.jumpSpeed;
            stats.stamina -= 10;
        }
    }

    //takes the current position of the player and teleports them x units in the direction they are facing
    //this only works while the player is jumping
    public void jumpTeleport()
    {
        if (stats.stamina >= 35)
        {
            //checks directions facing 
            if (stats.facing)
            {
                stats.nullActivity = true;
                teleport.checkLeft();
                //teleport certain distance away
                rb2d.gravityScale = 0;
                rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
                Invoke("jumpTeleportHelper", .1f);
            }
            else
            {
                stats.nullActivity = true;
                teleport.checkRight();
                //teleport a certain distance away
                rb2d.gravityScale = 0;
                rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
                Invoke("jumpTeleportHelper", .1f);
            }
            stats.stamina -= 35;
        }
    }

    public void jumpTeleportHelper()
    {
        teleport.left = false;
        teleport.right = false;

        rb2d.transform.position = stats.teleportCheck.transform.position;
        reset = false;

        teleport.count = 0;
        //Stop the check from moving
        teleport.transform.position = rb2d.transform.position;
        stats.nullActivity = false;
        Invoke("resetGravity", .05f);
    }

    //This may cause problems if other abilities give 0 gravity
    //Consider creating a multi-boolean lock that holds all
    //possible gravity 0 methods
    public void airFloat()
    {
        if (stats.stamina >= 2)
        {
            reset = false;
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
            rb2d.gravityScale = 0;
            stats.stamina -= 2;
            if (stats.stamina < 2)
            {
                resetGravity();
            }
        }
    }

    public void resetGravity()
    {
        if (reset == false)
        {
            rb2d.gravityScale = 1;
            reset = true;
        }
    }

    //player can use jetpack for 5 seconds before he must wait for a 
    //3 second cooldown when he can use the jetpack again
    public void jetpack()
    {
        if (!staminaChange)
        {
            staminaAmount = stats.staminaRechargeAmount;
            stats.staminaRechargeAmount = 0;
            staminaChange = true;
        }
        if (stats.stamina >= 2)
        {
            rb2d.velocity = new Vector2(rb2d.velocity.x, 2);
            stats.stamina -= 2;
        }
    }

    public void resetJetPack()
    {
        stats.staminaRechargeAmount = staminaAmount;
        staminaChange = false;
    }
}
