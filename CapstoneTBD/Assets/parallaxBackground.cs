using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class parallaxBackground : MonoBehaviour {

	public GameObject cameraOrigin;
	// private variables representing old position
	private float x = 0;
	private float y = 0;

	// the speed at which the parallax moves the image, default 1
	public float moveSpeedX = 1;
	public float moveSpeedY = 0.5f;

	void Start()
	{
		MenuController temp = GameObject.FindGameObjectWithTag("Player").GetComponentInChildren<MenuController>();
		cameraOrigin = temp.Camera;
	}

	public void FixedUpdate(){
		if (cameraOrigin.transform.position.x != x) {
			transform.position -= new Vector3 (((x - cameraOrigin.transform.position.x) * moveSpeedX), 0.0f, 0.0f);
			x = cameraOrigin.transform.position.x;
		}
		if (cameraOrigin.transform.position.y != y) {
			transform.position -= new Vector3 (0.0f,((y - cameraOrigin.transform.position.y) * moveSpeedY), 0.0f);
			y = cameraOrigin.transform.position.y;
		}
	}

}
