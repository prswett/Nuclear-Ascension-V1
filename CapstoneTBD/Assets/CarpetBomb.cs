using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CarpetBomb : MonoBehaviour {

	bool alreadyCollided;
	float velocityY = 0;
	Rigidbody2D rb2d;
	public int damage;
	public GameObject explosion;

	void Awake()
	{
		rb2d = GetComponent<Rigidbody2D>();
	}
	void Start () {
		Destroy(gameObject, 2f);
		alreadyCollided = false;
	}
	
	
	void Update () {
		velocityY -= .1f;	
		rb2d.velocity = new Vector2(0, velocityY);
	}
	
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
