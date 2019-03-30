using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility1Database : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;

    public float JetPackForce; //force to lift the player up
    public bool jetpackOn; //used to help simulate jetpack cooldown
    public bool stopVelocity = false;
    public float startTime; //amount of time player is allowed to use jetpack before refuel

    public bool emergencyEscapeCD;
    public bool tetherCD;

    //Currently used specficially for air float method
    public bool reset = false;

    public Vector2 tetherVector;

    public List<Vector2> listOfPosition = new List<Vector2>();

    //Used for teleport
    TeleportTarget teleport;

    private void Start()
    {
        JetPackForce = 21f;
        jetpackOn = true;
        startTime = 2.5f;
        listOfPosition.Add(rb2d.transform.position);
        listOfPosition[0] = rb2d.transform.position;
        emergencyEscapeCD = false;
        tetherCD = false;
    }

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        teleport = stats.teleportCheck.GetComponent<TeleportTarget>();
    }

    public void jump()
    {
        rb2d.velocity = Vector2.up * stats.jumpSpeed;
    }

    //takes the current position of the player and teleports them x units in the direction they are facing
    //this only works while the player is jumping
    //right now there is no cd for the ability so its super fucking op(prob need to fix)
    //Change to addforce instead
    public void jumpTeleport()
    {
        //checks directions facing 
        if (stats.facing)
        {
            stats.nullActivity = true;
            teleport.checkLeft();
            //teleport certain distance away
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
            Invoke("jumpTeleportHelper", .3f);
        }
        else
        {
            stats.nullActivity = true;
            teleport.checkRight();
            //teleport a certain distance away
            rb2d.gravityScale = 0;
            rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
            Invoke("jumpTeleportHelper", .3f);
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
        reset = false;
        rb2d.velocity = new Vector3(rb2d.velocity.x, 0, 0);
        rb2d.gravityScale = 0;
        Invoke("resetGravity", 1f);
    }

    public void resetGravity()
    {
        if (reset == false)
        {
            rb2d.gravityScale = 1;
            reset = true;
        }
    }

    public void emergencyEscape()
    {
        rb2d.transform.position = listOfPosition[0];
        Invoke("resetEmergencyEscape", 10f);
    }

    public void resetEmergencyEscape()
    {
        emergencyEscapeCD = false;
    }

    public void trackPlayerPosition()
    {
        Vector2 tempVector = rb2d.transform.position;
        StartCoroutine(MyFunction(tempVector,1f));
        
    }

    IEnumerator MyFunction(Vector2 myVector, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        listOfPosition[0] = myVector;
    }


    public void specialTether()
    {
        tetherVector = rb2d.transform.position;
        Invoke("tetherHelper", 3f);
    }

    public void tetherHelper()
    {
        rb2d.transform.position = tetherVector;
        Invoke("tetherReset",6f);
    }

    public void tetherReset()
    {
        tetherCD = false;
    }


    //player can use jetpack for 5 seconds before he must wait for a 
    //3 second cooldown when he can use the jetpack again
    public void jetpack()
    {
        if (jetpackOn == true)
        {
            if (!stopVelocity)
            {
                stopVelocity = true;
                rb2d.velocity = new Vector2(rb2d.velocity.x, 0);
            }
            startTime -= Time.deltaTime;
            rb2d.AddForce(Vector2.up * JetPackForce);

            //if you run out of time refuel jetpack in 3 seconds
            if (startTime <= 0.0f)
            {
                resetJetPack();
            }
        }
    }

    public void resetJetPack()
    {
        jetpackOn = false;
        Invoke("jetpackHelper", 3f);
    }

    //resets jetpack timer and marks it for player to use
    public void jetpackHelper()
    {
        startTime = 2.5f;
        jetpackOn = true;
        stopVelocity = false;
    }
}
