using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ToxicSpit : MonoBehaviour {

	public int damage;
	public Transform target;
	Vector3 targetLocation;
	public bool alreadyCollided = false;
	void Start () {
		Destroy(gameObject, 3f);
		targetLocation = (target.position - transform.position).normalized;
		transform.rotation = Quaternion.LookRotation(Vector3.forward, target.position - transform.position);
	}
	
	void Update () {
		transform.position += targetLocation * 2 * Time.deltaTime;
	}

	void OnTriggerEnter2D(Collider2D other)
    {
        
        if (other.CompareTag("Player") && alreadyCollided == false)
        {
            alreadyCollided = true;
            PlayerStatistics stats = other.GetComponent<PlayerStatistics>();
            stats.takeDamage(damage);
            Destroy(gameObject); 
        }

        if (other.CompareTag("Defense"))
        {
            Destroy(gameObject);
        }
    }
}
