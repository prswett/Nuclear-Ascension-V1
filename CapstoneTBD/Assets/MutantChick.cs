using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MutantChick : MonoBehaviour {

	public GameObject toxicSpit;
	public int damage;
	public GameObject[] players;
	public GameObject player;
	public float time;
	void Start () {
		players = GameObject.FindGameObjectsWithTag("Player");
		Destroy(gameObject, 10f);
	}
	
	
	void Update () {
		player = players[Random.Range(0, players.Length)];
		if (Time.time - time >= 2f || time == 0)
		{
			fire();
			time = Time.time;
		}
	}

	public void fire()
	{
		ToxicSpit bullet = toxicSpit.GetComponent<ToxicSpit>();
		bullet.target = player.transform;
		bullet.damage = damage;
		Instantiate(bullet, transform.position, Quaternion.identity);
	}
}
