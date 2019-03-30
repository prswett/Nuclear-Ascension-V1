using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerSpawn : MonoBehaviour {

	// Use this for initialization
	void Start () {
		GameObject[] players = GameObject.FindGameObjectsWithTag("Player");
		foreach (GameObject trackedPlayer in players)
        {
			trackedPlayer.transform.position = transform.position;
			MenuController temp = trackedPlayer.GetComponentInChildren<MenuController>();
			temp.Camera.SetActive(true);
        }
	}
}
