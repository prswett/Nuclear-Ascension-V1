using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TetherController : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			Utility2Database database = other.GetComponent<Utility2Database>();
			if (database.utility2Activated && database.activatedTether)
			{
				database.utility2Activated = false;
				database.activatedTether = false;
				Destroy(gameObject);
			}
		}
	}
}
