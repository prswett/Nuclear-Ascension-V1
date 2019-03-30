using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketBulletUp : MonoBehaviour
{


    public bool lockedOn = false;
    public Transform target;
    public float speed;
    public RocketHoming temp;

    public GameObject explosion;
    public int damage;
    float time;

    void Awake()
    {
        temp = GetComponentInChildren<RocketHoming>();
    }

    void Start()
    {
        speed = 2f;
        Destroy(gameObject, 4f);
        time = Time.time;
    }


    void Update()
    {
        if (lockedOn && target != null)
        {
            transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position);
        }
        else
        {
            transform.position += Vector3.up * speed * Time.deltaTime;
        }

        if (target == null)
        {
            temp.locked = false;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || (other.CompareTag("Boss")))
        {
            if (Time.time - time >= .1f)
            {
                RocketExplosion rocket = explosion.GetComponent<RocketExplosion>();
                rocket.damage = damage;
                Instantiate(explosion, transform.position, Quaternion.identity);
                Destroy(gameObject);
            }
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
