using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PenetrateBulletController : MonoBehaviour
{

    public float velocityX;
    public float velocityY;
    Rigidbody2D rb2d;

    public bool pierce = false;
    public int damage;
    bool hit = false;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Add penetration
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rb2d.velocity = new Vector2(velocityX, velocityY);
    }

    //If special attack, pierce
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!pierce)
            {
                if (!hit)
                {
                    hit = true;
                    EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                    enemyHealth.takeDamage(damage);
                    Destroy(gameObject);
                }
            }
            else
            {
                EnemyHealth enemyHealth = other.GetComponent<EnemyHealth>();
                enemyHealth.takeDamageWithCD(damage);
            }
        }

        if (other.CompareTag("Boss"))
        {
            if (!pierce)
            {
                if (!hit)
                {
                    hit = true;
                    BossHealth bossHealth = other.GetComponent<BossHealth>();
                    bossHealth.takeDamage(damage);
                    Destroy(gameObject);
                }
            }
            else
            {
                BossHealth bossHealth = other.GetComponent<BossHealth>();
                bossHealth.takeDamage(damage);
            }
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
