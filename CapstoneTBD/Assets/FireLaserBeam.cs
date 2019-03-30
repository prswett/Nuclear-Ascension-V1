using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FireLaserBeam : MonoBehaviour
{

    public int damage;
    public float time;

    void Start()
    {
        Destroy(gameObject, 2f);
		time = Time.time - 2f;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = new Vector2(transform.position.x - .25f, transform.position.y);
        transform.localScale = new Vector3(transform.localScale.x + 2f, transform.localScale.y + 0.1f, transform.localScale.z);
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - time >= .5f)
            {
                PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
                stats.takeDamage(damage);
                time = Time.time;
            }
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            if (Time.time - time >= .5f)
            {
                PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
                stats.takeDamage(damage);
                time = Time.time;
            }
        }
    }
}
