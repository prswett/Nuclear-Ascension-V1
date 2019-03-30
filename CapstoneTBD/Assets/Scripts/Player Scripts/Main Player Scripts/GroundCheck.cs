using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GroundCheck : MonoBehaviour {

	bool onGround;

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			onGround = true;
		}
	}

	void OnTriggerStay2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			onGround = true;
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Ground"))
		{
			onGround = false;
		}
	}
}
