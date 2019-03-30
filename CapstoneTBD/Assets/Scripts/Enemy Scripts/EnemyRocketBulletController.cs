using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyRocketBulletController : MonoBehaviour {

    public float velocityX;
    public float velocityY;
    Rigidbody2D rb2d;
    public float direction;
    public int damage;
    public bool alreadyCollided;
    public GameObject explosion;
    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        Destroy(gameObject, 1f);
        alreadyCollided = false;
    }

    void Update()
    {
        if (direction > 0)
        {
            velocityX += .1f;
        }
        else
        {
            velocityX -= .1f;
        }

        rb2d.velocity = new Vector2(velocityX, velocityY);
    }

    //Make it explode
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && alreadyCollided == false)
        {
            EnemyRocketExplosion rocket = explosion.GetComponent<EnemyRocketExplosion>();
            rocket.damage = damage;
            alreadyCollided = true;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Defense"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            EnemyRocketExplosion rocket = explosion.GetComponent<EnemyRocketExplosion>();
            rocket.damage = damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
