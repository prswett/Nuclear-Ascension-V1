using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense3Database : MonoBehaviour {

	PlayerStatistics stats;
	Rigidbody2D rb2d;

	void Awake()
	{
		stats = GetComponent<PlayerStatistics>();
		rb2d = GetComponent<Rigidbody2D>();
	}

	public void homingRocket()
	{
		RocketBulletUp bullet = stats.homingRocket.GetComponent<RocketBulletUp>();
		bullet.damage = stats.calculateDamage(stats.damage / 2);
		Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + .1f, 0), Quaternion.identity);
	}
}
