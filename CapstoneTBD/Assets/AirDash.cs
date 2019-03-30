using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class AirDash : MonoBehaviour {

	public int damage;
	public Transform target;
	Vector3 targetLocation;

	void Start () {
		Destroy(gameObject, 3f);
		targetLocation = (target.position - transform.position).normalized;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
	}
	
	void Update () {
		transform.position += targetLocation * 3 * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
            stats.takeDamage(damage);
            Destroy(gameObject); 
        }
    }
}
