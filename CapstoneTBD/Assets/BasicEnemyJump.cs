using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicEnemyJump : MonoBehaviour {

	public bool jump = false;
	Rigidbody2D rb2d;
	// Use this for initialization

	void Awake()
	{
		rb2d = GetComponentInParent<Rigidbody2D>();
	}

	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			if (!jump)
			{
				rb2d.velocity = Vector2.up * 3f;
				jump = true;
				Invoke("jumpHelper", .4f);
			}
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			if (!jump)
			{
				rb2d.velocity = Vector2.up * 3f;
				jump = true;
				Invoke("jumpHelper", .4f);
			}
		}
	}

	void jumpHelper()
	{
		jump = false;
	}
}
