using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LaserController : MonoBehaviour {

	public PlayerStatistics stats;
	public GameObject player;
	public Transform transform;
	public int damage;
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		stats = player.GetComponent<PlayerStatistics>();
		transform = GetComponent<Transform>();
	}

	void Start() {
		stats.nullActivity = true;
		Invoke("allowMovement", .3f); 
		Destroy(gameObject, .3f);
		if (stats.facing) {
			transform.position = new Vector2(player.transform.position.x - .2f, player.transform.position.y);
		} else {
			transform.position = new Vector2(player.transform.position.x + .2f, player.transform.position.y);
		}
	}
	
	void Update () {
		if (stats.facing) {
			transform.position = new Vector2(transform.position.x - .25f, player.transform.position.y);
		} else {
			transform.position = new Vector2(transform.position.x + .25f, player.transform.position.y);
		}
		transform.localScale = new Vector3(transform.localScale.x + 2f, transform.localScale.y + 0.1f, transform.localScale.z);
	}

	void allowMovement() {
		stats.nullActivity = false;
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
			enemyhealth.takeDamageWithCD(damage + stats.damage);
		}

		if (other.CompareTag("Boss"))
		{
			BossHealth bosshealth = other.GetComponent<BossHealth>();
			bosshealth.takeDamageWithCD(damage + stats.damage);
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			EnemyHealth enemyhealth = other.GetComponent<EnemyHealth>();
			enemyhealth.takeDamageWithCD(damage + stats.damage);
		}

		if (other.CompareTag("Boss"))
		{
			BossHealth bosshealth = other.GetComponent<BossHealth>();
			bosshealth.takeDamageWithCD(damage + stats.damage);
		}
	}
}
