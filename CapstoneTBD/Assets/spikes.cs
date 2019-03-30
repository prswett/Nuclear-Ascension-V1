using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class spikes : MonoBehaviour {

	public double damage;
	public bool inside;

	// initializing player to manipulate health
	void Awake()
	{
	}

	// if collision set inside spikes to true
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			inside = true;
			StartCoroutine (InSpikes (other.GetComponent<PlayerStatistics>()));
		}
	}

	// if leaving spikes
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			inside = false;
			StopCoroutine (InSpikes (other.GetComponent<PlayerStatistics>()));
		}
	}

	// damaging helping method
	IEnumerator InSpikes(PlayerStatistics stats)
	{
		// checking inside spikes
		while (inside)
		{
			// constant damage
			float damage = (int)(stats.GetComponent<PlayerStatistics>().maxHealth / 50f);
			if (damage == 0)
			{
				damage = 1;
			}
			stats.takeDamage(damage);
			yield return new WaitForSeconds(0.2f);
		}
	}
}
