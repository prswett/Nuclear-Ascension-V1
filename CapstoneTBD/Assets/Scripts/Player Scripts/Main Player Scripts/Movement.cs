using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{

    PlayerStatistics stats;
    public bool running = false;
    public bool canMoveForward;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        canMoveForward = true;
    }

    void Update()
    {
    }

    public void run(bool input)
    {
        running = input;
    }

    public void left()
    {
        if (!stats.facing)
        {
            flip();
        }

        if (canMoveForward)
        {
            //Checks if player is running
            if (running && stats.stamina >= 2)
            {
                transform.position += Vector3.left * stats.runSpeed * Time.deltaTime;
                stats.stamina -= 2;
            }
            else
            {
                transform.position += Vector3.left * stats.walkSpeed * Time.deltaTime;
            }
        }
    }

    public void right()
    {
        if (stats.facing)
        {
            flip();
        }

        if (canMoveForward)
        {
            //Checks if player is running
            if (running && stats.stamina >= 2)
            {
                transform.position += Vector3.right * stats.runSpeed * Time.deltaTime;
                stats.stamina -= 2;
            }
            else
            {
                transform.position += Vector3.right * stats.walkSpeed * Time.deltaTime;
            }
        }
    }

    //Flips the player and changes PlayerStatistics to match.
    //Used for making the player face the way they are walking.
    public void flip()
    {
        stats.facing = !stats.facing;
        Vector3 charscale = transform.localScale;
        charscale.x *= -1;
        transform.localScale = charscale;
    }
}
