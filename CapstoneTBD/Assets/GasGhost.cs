using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GasGhost : MonoBehaviour {

	public int damage;
	public float time;
	public Transform target;
	public float speed;
	
	void Start()
	{
		time = Time.time;
		speed = .75f;
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		if (target != null)
		{
			transform.position = Vector3.MoveTowards(transform.position, target.transform.position, speed * Time.deltaTime);
		}
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
