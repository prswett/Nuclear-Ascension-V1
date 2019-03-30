using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PoisonBuff : MonoBehaviour {

	public Transform boss;
	void Start () {
		Destroy(gameObject, 2f);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position = boss.transform.position;
	}
}
