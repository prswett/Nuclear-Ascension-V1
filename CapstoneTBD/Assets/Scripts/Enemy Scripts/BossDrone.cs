using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossDrone : MonoBehaviour
{


    public Transform player;
    public int damage;
    public float shootDist;
    public float MinDist;
    public float speed;
    public bool touchingPlatform = false;
    public GameObject bullet;

    EnemyStats stats;
    void Awake()
    {
        stats = GetComponentInChildren<EnemyStats>();
    }
    
    void Start()
    {
        damage = stats.damage;
    }
    public Vector2 playerPosition;
    public Vector2 myPosition;
    bool shoot = false;
    void Update()
    {
        playerPosition = new Vector2(0, player.transform.position.y);
        myPosition = new Vector2(0, transform.position.y);

        if (Vector2.Distance(playerPosition, myPosition) > MinDist)
        {
            if (touchingPlatform)
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
            }
            else
            {
                transform.position = Vector3.MoveTowards(transform.position, player.transform.position, speed * Time.deltaTime);
                if (player.transform.position.y > transform.position.y)
                {
                    transform.Translate(Vector2.up * speed * Time.deltaTime);
                }
            }
        }

        if (!shoot)
        {
            fire();
            shoot = true;
            Invoke("reload", 1f);
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
