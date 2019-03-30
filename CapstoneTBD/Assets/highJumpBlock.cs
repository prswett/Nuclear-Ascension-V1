using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class highJumpBlock : MonoBehaviour {

	public Vector2 verticalJump = new Vector2 (0.0f, 5.0f);

	void Awake()
	{

	}

	// if collision add vertical force
	void OnTriggerEnter2D(Collider2D other){
		if(other.CompareTag("Player")){
			// since speed cap, additionally add verical velocity
			StartCoroutine (playerJump(other.GetComponent<Rigidbody2D>()));
		}
	}

	// delayed spurts of speed to keep up speed
	IEnumerator playerJump(Rigidbody2D rb2d){
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
		yield return new WaitForSeconds(0.01f);
		rb2d.velocity += verticalJump;
	}

}
