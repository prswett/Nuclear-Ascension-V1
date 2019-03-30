using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicFlyingEnemy : MonoBehaviour
{

    public GameObject[] players;
    public GameObject player; //player
    Vector3 targetPosition;


    public float MinDist; //min distance before enemy engages player/detects player
    public float shootDist;
    public float speed; //speed that the enemy will chase the player
    public float currentMarkPoint;
    public int damage;

    public int randomMarkpoint;

    EnemyController enemystuff; //grabbing bullet animations from controller (will be used later for better integration)

    public float left;
    public float right;
    public float top;
    public float bottom;

    public Vector3 mark1;
    public Vector3 mark2;
    public Vector3 mark3;
    public Vector3 mark4;
    public Vector3 mark5;
    public Vector3 mark6;
    public Vector3 mark7;
    public Vector3 mark8;
    public Vector3 mark9;
    public Vector3 mark10;

    public GameObject bullet;

    public bool touchingPlatform = false;

    EnemyStats stats;
    void Awake()
    {
        stats = GetComponentInChildren<EnemyStats>();
    }

    // Use this for initialization
    void Start()
    {
        currentMarkPoint = 5;
        randomMarkpoint = Random.Range(1, 10);

        players = GameObject.FindGameObjectsWithTag("Player");

        mark1 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark2 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark3 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark4 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark5 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark6 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark7 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark8 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark9 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark10 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));

        shootDist = Random.Range(MinDist, MinDist + 2f);
        damage = stats.damage;
    }

    float dist;
    bool follow = false;
    public Vector2 playerPosition;
    public Vector2 myPosition;
    public bool shoot = false;
    void Update()
    {
        foreach (GameObject trackedPlayer in players)
        {
            dist = Vector3.Distance(trackedPlayer.transform.position, transform.position);
            if (dist < MinDist)
            {
                player = trackedPlayer;
                break;
            }
            else
            {
                player = trackedPlayer;
            }
        }

        if (!follow)
        {
            playerPosition = new Vector2(player.transform.position.x, player.transform.position.y);
            myPosition = new Vector2(transform.position.x, transform.position.y);
            if (Vector2.Distance(playerPosition, myPosition) < MinDist * 2)
            {
                follow = true;
            }
        }

        if (follow)
        {
            playerPosition = new Vector2(0, player.transform.position.y);
            myPosition = new Vector2(0, transform.position.y);

            if (touchingPlatform)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else if (Vector2.Distance(playerPosition, myPosition) > MinDist)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                if (player.transform.position.y > transform.position.y)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }

            if (Vector2.Distance(playerPosition, myPosition) < shootDist)
            {
                if (!shoot)
                {
                    fire();
                    shoot = true;
                    Invoke("reload", 1f);
                }
            }

        }
        else
        {
            patrol();
        }
    }

    void fire()
    {
        FlyingBullet temp = bullet.GetComponent<FlyingBullet>();
        temp.targetPlayer = player.transform;
        temp.damage = damage;
        Instantiate(temp, transform.position, Quaternion.identity);
    }

    public void reload()
    {
        shoot = false;
    }

    void patrol()
    {
        switch (randomMarkpoint)
        {
            case 1:
                targetPosition = mark1;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 2:
                targetPosition = mark2;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 3:
                targetPosition = mark3;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 4:
                targetPosition = mark4;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 5:
                targetPosition = mark5;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 6:
                targetPosition = mark6;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 7:
                targetPosition = mark7;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 8:
                targetPosition = mark8;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 9:
                targetPosition = mark9;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
            case 10:
                targetPosition = mark10;
                transform.position = Vector3.MoveTowards(transform.position, targetPosition, speed * Time.deltaTime);
                if (Vector3.Distance(transform.position, targetPosition) < .03f)
                {
                    randomMarkpoint = Random.Range(1, 10);
                }
                break;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchingPlatform = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Ground"))
        {
            touchingPlatform = false;
        }
    }
}
