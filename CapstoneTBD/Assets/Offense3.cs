using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense3 : MonoBehaviour {

	PlayerStatistics stats;
	Rigidbody2D rb2d;
	Offense3Database database;

	public float timer;

	void Awake()
	{
		stats = GetComponent<PlayerStatistics>();
		database = GetComponent<Offense3Database>();
	}

	public void attack()
	{
		if (Time.time - timer >= stats.offense3cd || timer == 0)
		{
			switch (stats.offense3)
			{
				default:
				timer = Time.time;
				database.homingRocket();
				break;
			}
		}
	}
}
