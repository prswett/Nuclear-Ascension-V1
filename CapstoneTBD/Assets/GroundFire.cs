using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundFire : MonoBehaviour {

	public int damage;
	// Use this for initialization
	void Start () {
		Destroy(gameObject, 1f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
        {
            PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
            stats.takeDamage(damage);
        }
	}
}
