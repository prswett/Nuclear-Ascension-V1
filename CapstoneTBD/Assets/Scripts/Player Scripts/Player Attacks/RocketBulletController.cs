using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBulletController : MonoBehaviour {

    public float velocityX;
    public float velocityY;
    Rigidbody2D rb2d;
    public float direction;
    public int damage;
    public GameObject explosion;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        velocityX = 0;
        Destroy(gameObject, 3f);
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
        if (other.CompareTag("Enemy"))
        {
            RocketExplosion rocket = explosion.GetComponent<RocketExplosion>();
            rocket.damage = damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Boss"))
        {
            RocketExplosion rocket = explosion.GetComponent<RocketExplosion>();
            rocket.damage = damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            RocketExplosion rocket = explosion.GetComponent<RocketExplosion>();
            rocket.damage = damage;
            Instantiate(explosion, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
