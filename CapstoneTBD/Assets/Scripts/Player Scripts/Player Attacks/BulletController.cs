using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BulletController : MonoBehaviour
{

    public float velocityX;
    public float velocityY;
    Rigidbody2D rb2d;
    public int damage;
    bool hit = false;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        Destroy(gameObject, 3f);
    }

    void Update()
    {
        rb2d.velocity = new Vector2(velocityX, velocityY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy"))
        {
            if (!hit)
            {
                hit = true;
                EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
                enemyhealth.takeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Boss"))
        {
            if (!hit)
            {
                hit = true;
                BossHealth bossHealth = other.GetComponent<BossHealth>();
                bossHealth.takeDamage(damage);
                Destroy(gameObject);
            }
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
