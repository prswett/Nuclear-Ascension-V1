using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PistolEnemy : MonoBehaviour
{

    public GameObject[] players; //player
    public GameObject player;

    public bool goRight = false; //enemy moves to the right
    public bool goLeft = false; //enemy moves to the left

    public bool facing = false; //used for animation flipping later 
    public bool shootcd = false;
    public float MinDist; //min distance before enemy engages player/detects player
    public float speed = 1; //basic patrol speed of the enemy

    public GameObject PistolBullet;

    void Start()
    {
        //setting stuff
        float randomValue = Random.value;
        players = GameObject.FindGameObjectsWithTag("Player");

        //when the game loads this will choose a random direction for the enemy to start patroling in
        //used to give some uniqueness to enemy patrol paterns 
        if (randomValue > .5)
        {
            goRight = true;
        }
        else
        {
            goLeft = true;
            flip();
        }

        damage = stats.damage;
    }

    float dist;
    public float leftMarker;
    public float rightMarker;
    public bool shooting = false;
    public bool follow;

    public Vector2 playerPosition;
    public Vector2 myPosition;

    public int damage;
    EnemyStats stats;
    void Awake()
    {
        stats = GetComponentInChildren<EnemyStats>();
    }

    void Update()
    {
        foreach (GameObject trackedPlayer in players)
        {
            if (trackedPlayer != null)
            {
                dist = Vector3.Distance(trackedPlayer.transform.position, transform.position);
                if (leftMarker < trackedPlayer.transform.position.x || rightMarker > trackedPlayer.transform.position.x)
                {
                    player = trackedPlayer;
                    break;
                }
                else
                {
                    player = trackedPlayer;
                }
            }
        }

        if (!shooting)
        {
            if (!follow)
            {
                playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
                myPosition = new Vector2(transform.position.x, transform.position.y);
                if (Vector2.Distance(playerPosition, myPosition) < MinDist)
                {
                    follow = true;
                }
            }

            if (follow)
            {
                playerPosition = new Vector2(0, player.transform.position.y);
                myPosition = new Vector2(0, transform.position.y);
                if (Vector2.Distance(playerPosition, myPosition) > .1)
                {
                    if (player.transform.position.x < transform.position.x)
                    {
                        if (!facing)
                        {
                            flip();
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, 0), speed * Time.deltaTime);
                    }
                    else
                    {
                        if (facing)
                        {
                            flip();
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, 0), speed * Time.deltaTime);
                    }
                }
                else if (dist < MinDist)
                {
                    if (!shootcd)
                    {
                        shooting = true;
                        shootcd = true;
                        Invoke("basicEnemyPistol", 1f);
                        Invoke("reload", 1f);
                    }
                }
                else
                {
                    playerPosition = new Vector2(player.transform.position.x, 0);
                    myPosition = new Vector2(transform.position.x, 0);
                    if (player.transform.position.x < transform.position.x && Vector2.Distance(playerPosition, myPosition) > .3f)
                    {
                        if (!facing)
                        {
                            flip();
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, 0), speed * Time.deltaTime);
                    }
                    else if (Vector2.Distance(playerPosition, myPosition) > .3f)
                    {
                        if (facing)
                        {
                            flip();
                        }
                        transform.position = Vector3.MoveTowards(transform.position, new Vector3(player.transform.position.x, transform.position.y, 0), speed * Time.deltaTime);
                    }
                }
            }
            else
            {
                basicMovement();
            }
        }
        //checks the distance between enemy and markpoints
        //if to close to the markpoints enemy will stop chasing player

        if (leftMarker > transform.position.x)
        {
            goLeft = false;
            goRight = true;
        }
        else if (rightMarker < transform.position.x)
        {
            goLeft = true;
            goRight = false;
        }
    }

    public void reload()
    {
        shootcd = false;
    }

    //basic enemy movement once the player is detected 
    public void basicMovement()
    {
        //sets the direction of the enemy based off of bools set by checking distance between markpoints
        if (goLeft)
        {
            if (!facing)
            {
                flip();
            }
            transform.position += Vector3.left * speed * Time.deltaTime;
        }
        else
        {
            if (facing)
            {
                flip();
            }
            transform.position += Vector3.right * speed * Time.deltaTime;
        }
    }

    //code to fire pistol shot (same code player uses - damage stuff)
    public void basicEnemyPistol()
    {
        EnemyBulletController bullet = PistolBullet.GetComponent<EnemyBulletController>();
        bullet.damage = damage;
        if (player.transform.position.x > transform.position.x)
        {
            bullet.velocityX = 2;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -2;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        shooting = false;
    }

    //not used right now but may be needed later
    void flip()
    {
        facing = !facing;
        Vector3 charscale = transform.localScale;
        charscale.x *= -1;
        transform.localScale = charscale;
    }
}
