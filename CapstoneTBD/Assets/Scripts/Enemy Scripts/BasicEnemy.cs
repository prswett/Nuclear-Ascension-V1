using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemy : MonoBehaviour
{

    public GameObject[] players; //player
    public GameObject player;
    public Transform playerTransform; //players transform

    public bool goRight = false; //enemy moves to the right
    public bool goLeft = false; //enemy moves to the left

    public bool facing = false; //used for animation flipping later 
    public bool specialDelay; //cd on shooting
    public float MinDist; //min distance before enemy engages player/detects player
    public float speed = 1; //basic patrol speed of the enemy
    public float specialSpeed; //speed that the enemy will chase the player
    public float enemyAbility; //chooses the ability that the enemy will use upon game loading 
    public bool outOfBounds; // checks to see if the enemy can still chase the player

    PlayerStatistics stats;
    EnemyController enemystuff; //grabbing bullet animations from controller (will be used later for better integration)

    // Use this for initialization
    void Start()
    {
        //setting stuff
        float randomValue = Random.value;
        specialDelay = false;
        stats = GetComponent<PlayerStatistics>();
        enemystuff = GetComponent<EnemyController>();
        outOfBounds = false;
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
    }


    float dist;
    public float leftMarker;
    public float rightMarker;
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject trackedPlayer in players)
        {
            dist = Vector3.Distance(trackedPlayer.transform.position, transform.position);
            if (leftMarker < transform.position.x || rightMarker > transform.position.x)
            {
                player = trackedPlayer;
                break;
            }
            else
            {
                player = trackedPlayer;
            }
        }

        //sets speed of enemy 
        float step = specialSpeed * Time.deltaTime;

        //delay method that invokes enemy shooting
        if (specialDelay == false)
        {
            basicMovement();
        }

        //checks the distance between enemy and markpoints
        //if to close to the markpoints enemy will stop chasing player

        if (leftMarker >= transform.position.x)
        {
            outOfBounds = true;
            goLeft = false;
            goRight = true;
        }
        else if (rightMarker <= transform.position.x)
        {
            outOfBounds = true;
            goLeft = true;
            goRight = false;
        }


        //if the enemy is not out of bounds then continue to chase the player
        if (outOfBounds == false)
        {
            if (dist < MinDist)
            {
                if (dist > 0.2f)
                {
                    if (player.transform.position.x < transform.position.x)
                    {
                        if (facing == false)
                        {
                            flip();
                        }
                    }
                    else
                    {
                        if (facing == true)
                        {
                            flip();
                        }
                    }
                    transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
                }
            }
        }

        //if the enemy is not near the markpoints then set it so that it will chase the player,
        //the next time that it steps into range
        if (rightMarker > transform.position.x && leftMarker < transform.position.x)
        {
            outOfBounds = false;
        }
    }

    //basic enemy movement once the player is detected 
    public void basicMovement()
    {
        //calculate the distance between the enemy and the player
        float dist = Vector3.Distance(player.transform.position, transform.position);

        //if the player is in a certain range then call shoot/playerdetected method 
        if (dist < MinDist)
        {
            specialDelay = true;
            Invoke("playerDetected", 1f);
        }
        else
        {

            //sets the direction of the enemy based off of bools set by checking distance between markpoints
            if (goLeft)
            {
                transform.position += Vector3.left * speed * Time.deltaTime;
            }

            if (goRight)
            {
                transform.position += Vector3.right * speed * Time.deltaTime;
            }
        }
    }

    //method to be called when delay is not active and a player is detected by the enemy
    public void playerDetected()
    {

        //fires a pistol shot
        if (enemyAbility == 0)
        {
            basicEnemyPistol();
        }

        //fires a rocket
        if (enemyAbility == 1)
        {
            basicEnemyRocket();
        }

        //fires the laser
        if (enemyAbility == 2)
        {
            basicEnemyLaserProjectile();
        }

        //fires a riffle shot
        if (enemyAbility == 3)
        {
            basicEnemyRiffle();
        }

        //enemy fires gatling shot
        if (enemyAbility == 4)
        {
            basicEnemyGatling();
        }

        //create a shorter cooldown for the shots if gatling
        if (enemyAbility == 4)
        {

            Invoke("turnDelayOff", .01f);
        }
        //all other weapons have the same cd/fire rate
        else
        {
            Invoke("turnDelayOff", 1f);
        }

    }

    //code to fire pistol shot (same code player uses - damage stuff)
    public void basicEnemyPistol()
    {
        EnemyBulletController bullet = enemystuff.bullet.GetComponent<EnemyBulletController>();
        if (player.transform.position.x > transform.position.x)
        {
            bullet.velocityX = 2;
            Instantiate(bullet, new Vector3(transform.position.x + .1f, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -2;
            Instantiate(bullet, new Vector3(transform.position.x - .1f, transform.position.y, 0), Quaternion.identity);
        }
    }

    //code to fire Rocket shot (same code player uses - damage stuff)
    public void basicEnemyRocket()
    {
        EnemyRocketBulletController bullet = enemystuff.rocketBullet.GetComponent<EnemyRocketBulletController>();
        if (player.transform.position.x > transform.position.x)
        {
            bullet.velocityX = 1;
            bullet.direction = 1;
            Instantiate(bullet, new Vector3(transform.position.x + .1f, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -1;
            bullet.direction = -1;
            Instantiate(bullet, new Vector3(transform.position.x - .1f, transform.position.y, 0), Quaternion.identity);
        }
    }

    //code to fire laserProjectile shot (same code player uses - damage stuff)
    public void basicEnemyLaserProjectile()
    {
        EnemyLaserProjectileController laser = enemystuff.laserbeamprojectile.GetComponent<EnemyLaserProjectileController>();
        if (player.transform.position.x > transform.position.x)
        {
            laser.velocityX = 3;
            Instantiate(laser, new Vector3(transform.position.x + .15f, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            laser.velocityX = -3;
            Instantiate(laser, new Vector3(transform.position.x - .15f, transform.position.y, 0), Quaternion.identity);
        }
    }

    //code to fire riffle shot (same code player uses - damage stuff)
    public void basicEnemyRiffle()
    {
        EnemyPenetrateBulletController bullet = enemystuff.penetrateBullet.GetComponent<EnemyPenetrateBulletController>();
        if (player.transform.position.x > transform.position.x)
        {
            bullet.velocityX = 2;
            Instantiate(bullet, new Vector3(transform.position.x + .1f, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -2;
            Instantiate(bullet, new Vector3(transform.position.x - .1f, transform.position.y, 0), Quaternion.identity);
        }
    }

    //code to fire Gatling shot (same code player uses - damage stuff)
    public void basicEnemyGatling()
    {
        EnemyBulletController bullet = enemystuff.gatlingBullet.GetComponent<EnemyBulletController>();
        if (player.transform.position.x > transform.position.x)
        {
            bullet.velocityX = 2;
            Instantiate(bullet, new Vector3(transform.position.x + .1f, transform.position.y + Random.Range(-.05f, .05f), 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -2;
            Instantiate(bullet, new Vector3(transform.position.x - .1f, transform.position.y + Random.Range(-.05f, .05f), 0), Quaternion.identity);
        }
    }

    //helper method for turning off delay on enemy reaction and shooting cd
    public void turnDelayOff()
    {
        specialDelay = false;
    }

    public void setEnemyWeapon(int leability)
    {
        if (leability >= 0 && leability <= 4)
        {
            enemyAbility = leability;
        }
        else
        {
            enemyAbility = 0;
        }
    }

    public void setChaseSpeed(float cSpeed)
    {
        specialSpeed = cSpeed;
    }

    public void setAggroDistance(float aggro)
    {
        MinDist = aggro;
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
