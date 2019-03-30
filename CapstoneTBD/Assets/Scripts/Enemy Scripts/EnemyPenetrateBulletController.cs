using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyPenetrateBulletController : MonoBehaviour {

    public float velocityX;
    public float velocityY;
    Rigidbody2D rb2d;

    public bool pierce = false;
    public int damage;
    public bool alreadyCollided;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Add penetration
    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        Destroy(gameObject, 1f);
        alreadyCollided = false;
    }

    void Update()
    {
        rb2d.velocity = new Vector2(velocityX, velocityY);
    }

    //If special attack, pierce
    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player") && alreadyCollided == false)
        {
            PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
            stats.takeDamage(damage);
            Destroy(gameObject);
            alreadyCollided = true;
        }

        if (other.CompareTag("Defense"))
        {
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
