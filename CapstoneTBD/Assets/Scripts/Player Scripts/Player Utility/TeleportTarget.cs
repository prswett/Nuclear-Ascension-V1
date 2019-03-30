using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TeleportTarget : MonoBehaviour
{

    public bool left = false;
    public bool right = false;
    public Vector3 location;
    public bool nextToWall;

    public int count = 0;
    // Use this for initialization
    void Start()
    {
        nextToWall = false;
    }

    // Update is called once per frame
    void Update()
    {
        if (left && !nextToWall)
        {
            if (count < 5)
            {
                transform.position = new Vector3(transform.position.x - .1f, transform.position.y, 0);
                count++;
            }
        }
        if (right && !nextToWall)
        {
            if (count < 5)
            {
                transform.position = new Vector3(transform.position.x + .1f, transform.position.y, 0);
                count++;
            }
        }
    }

    public void checkLeft()
    {
        left = true;
        location = transform.position;
    }

    public void checkRight()
    {
        right = true;
        location = transform.position;
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            left = false;
            right = false;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            nextToWall = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            nextToWall = false;
        }
    }
}
