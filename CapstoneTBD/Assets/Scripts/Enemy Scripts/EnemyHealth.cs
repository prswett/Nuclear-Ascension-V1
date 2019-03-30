using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EnemyHealth : MonoBehaviour {

	public EnemyStats stats;
	public float health;
	public float timer;

	public GameObject relic;
	public GameObject specialRelic;
	
	void Awake() {
		stats = GetComponent<EnemyStats>();
	}
	void Start () {
		health = stats.maxHealth;
	}

	public void takeDamage(float damage)
	{
		//Maybe some defense calculated here or something
		health -= damage;

		if (health <= 0) {
			Destroy();
		}
	}

	public void takeDamageWithCD(float damage)
	{
		if (Time.time - timer >= 2f || timer == 0)
		{
			health -= damage;
			timer = Time.time;
		}

		if (health <= 0) {
			Destroy();
		}
	}

	public void takeDamageWithCDInput(float damage, float time)
	{
		if (Time.time - timer >= time || timer == 0)
		{
			health -= damage;
			timer = Time.time;
		}

		if (health <= 0) {
			Destroy();
		}
	}

	void Destroy() {
		int roll = Random.Range(0, 10);
		if (roll < 1)
		{
			roll = Random.Range(0, 10);
			if (roll < 2)
			{
				//Need to implement special relics first
				//Instantiate(specialRelic, transform.position, Quaternion.identity);
				Instantiate(relic, transform.position, Quaternion.identity);
			}
			else{
				Instantiate(relic, transform.position, Quaternion.identity);
			}
		}
		Destroy(transform.parent.gameObject);
	}
}
