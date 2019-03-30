using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossEgg : MonoBehaviour {

	public GameObject PoisonChick;
	public int damage;
	void Start () {
		Invoke("spawn", 2f);
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void spawn()
	{
		MutantChick chick = PoisonChick.GetComponent<MutantChick>();
		chick.damage = damage;
		Instantiate(PoisonChick, transform.position, Quaternion.identity);
		Destroy(gameObject);
	}
}
