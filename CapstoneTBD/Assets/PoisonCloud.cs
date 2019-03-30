using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonCloud : MonoBehaviour {

	public int damage;
	public float time;
	void Start () {
		time = Time.time;
		Destroy(gameObject, 3f);
	}
	
	// Update is called once per frame
	void Update () {
		
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
