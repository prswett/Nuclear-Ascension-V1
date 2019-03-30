using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ActivateSpawn : MonoBehaviour {

	EnemySpawner spawner;
	void Awake()
	{
		spawner = GetComponentInParent<EnemySpawner>();
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Spawn"))
        {
            spawner.spawn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Spawn"))
        {
            spawner.spawn = false;
        }
    }
}
