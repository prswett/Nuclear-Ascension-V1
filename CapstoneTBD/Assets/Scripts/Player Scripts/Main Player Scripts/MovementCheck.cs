using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementCheck : MonoBehaviour {

	Movement movement;

	void Awake()
	{
		movement = GetComponentInParent<Movement>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			movement.canMoveForward = false;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			movement.canMoveForward = false;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			movement.canMoveForward = true;
		}
	}
}
