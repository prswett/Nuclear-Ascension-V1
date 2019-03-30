using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPistolBullet : MonoBehaviour {

	public float velocityX;
    public float velocityY;
    public int damage;
    Rigidbody2D rb2d;
    public bool alreadyCollided;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    void Start()
    {
        transform.rotation = Quaternion.LookRotation(Vector3.forward, new Vector3(0, velocityX, 0));
        Destroy(gameObject, 4f);
        alreadyCollided = false;
    }

    void Update()
    {
        rb2d.velocity = new Vector2(velocityX, velocityY);
    }

    void OnTriggerEnter2D(Collider2D other)
    {

        if (other.CompareTag("Player") && alreadyCollided == false)
        {
            alreadyCollided = true;
            PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
            stats.takeDamage(damage);
            Destroy(gameObject); 
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
