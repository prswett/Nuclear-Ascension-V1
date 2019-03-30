using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FlyingBullet : MonoBehaviour {

	public int damage;
	public Transform targetPlayer;
    Vector3 target;
	public bool alreadyCollided;

	// Use this for initialization
	void Start () {
		
		Destroy(gameObject, 1f);
		alreadyCollided = false;
        target = (targetPlayer.position - transform.position).normalized;
        transform.rotation = Quaternion.LookRotation(Vector3.forward, targetPlayer.position - transform.position);
	}
	
	// Update is called once per frame
	void Update () {
		transform.position += target * 2 * Time.deltaTime;
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

        if (other.CompareTag("Ground"))
        {
            Destroy(gameObject);
        }
    }
}
