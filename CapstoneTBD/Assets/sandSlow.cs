using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sandSlow : MonoBehaviour {

	Rigidbody2D rb2d;
	GameObject player;
	public bool inside;
	PlayerStatistics stats;


	// initializing player and getting rigidbody to manipulate force
	void Awake()
	{
		player = GameObject.FindGameObjectWithTag ("Player");
		rb2d = player.GetComponent<Rigidbody2D> ();
	}

	// if collision set inside sand to true
	void OnTriggerEnter2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
			stats.walkSpeed = .5f;
			stats.runSpeed = .75f;
			stats.jumpSpeed = 0;
			//inside = true;
			//StartCoroutine (InSand ());
		}
	}

	// if leaving sand
	void OnTriggerExit2D(Collider2D other){
		if (other.CompareTag ("Player")) {
			PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
			stats.applyDefaults();
			//inside = false;
			//StopCoroutine (InSand ());
		}
	}

	// helping method to slow player
	IEnumerator InSand()
	{
		// checking inside sand
		while (inside)
		{
			// slowfall in sand
			rb2d.velocity -= new Vector2(rb2d.velocity.x * 0.5f, rb2d.velocity.y * 0.5f);
			yield return new WaitForSeconds(0f);
		}
	}
}
