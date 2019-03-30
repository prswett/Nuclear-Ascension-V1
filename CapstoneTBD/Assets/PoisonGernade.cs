using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonGernade : MonoBehaviour
{

    public int damage;
    public Rigidbody2D rb2d;
    public GameObject explosion;
	public int velocityX;
	public int velocityY;

    void Awake()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 4f);
		rb2d.AddForce(new Vector2(velocityX, velocityY));
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PoisonGernadeExplosion poison = explosion.GetComponent<PoisonGernadeExplosion>();
            poison.damage = damage;
            Instantiate(poison, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }

        if (other.CompareTag("Ground"))
        {
            PoisonGernadeExplosion poison = explosion.GetComponent<PoisonGernadeExplosion>();
            poison.damage = damage;
            Instantiate(poison, transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}
