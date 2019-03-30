using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerJump : MonoBehaviour {

	Rigidbody2D rb2d;
	float jumpSpeed = 3;
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	public void jump()
    {
        rb2d.velocity = Vector2.up * jumpSpeed;
    }
}
