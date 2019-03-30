using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ShieldController : MonoBehaviour {

	public PlayerStatistics stats;
	public GameObject player;
	void Awake () {
		player = GameObject.FindGameObjectWithTag("Player");
		stats = player.GetComponent<PlayerStatistics>();
	}

	void Start() {
		Destroy(gameObject, 3f);
	}
	
	void Update () {
		if (stats.facing) {
			transform.position = new Vector2(player.transform.position.x - .1f, player.transform.position.y);
		} else {
			transform.position = new Vector2(player.transform.position.x + .1f, player.transform.position.y);
		}
	}
}
