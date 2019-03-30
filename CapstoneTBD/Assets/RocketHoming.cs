using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RocketHoming : MonoBehaviour {

	public bool locked = false;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Enemy"))
		{
			if (!locked)
			{
				RocketBulletUp temp = GetComponentInParent<RocketBulletUp>();
				temp.target = other.transform;
				locked = true;
				temp.lockedOn = true;
			}
		}

		if (other.CompareTag("Boss"))
        {
            if (!locked)
			{
				RocketBulletUp temp = GetComponentInParent<RocketBulletUp>();
				temp.target = other.transform;
				locked = true;
				temp.lockedOn = true;
			}
        }
	}
}
