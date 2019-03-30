using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHomingMissile : MonoBehaviour {

	public bool alreadyCollided = false;
	public GameObject explosion;
	public int damage;
	public Transform target;
	public float speed;
	Vector3 targetLocation;
	// Use this for initialization
	void Start () {
		speed = 2f;
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.position, speed * Time.deltaTime);
            //transform.rotation = Quaternion.LookRotation(Vector3.forward, target.transform.position); 
		}
		else
        {
			targetLocation = (target.position - transform.position).normalized;
            transform.position += targetLocation * 2 * Time.deltaTime;
			//transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
        }
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
