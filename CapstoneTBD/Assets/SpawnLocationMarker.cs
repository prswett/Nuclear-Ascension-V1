using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnLocationMarker : MonoBehaviour {

	public int position;
	public BoxCollider2D box;
	void Start () {
		switch (position)
        {
            case 3:
                transform.localPosition = new Vector3(box.size.x / 2f, 0, 0);
                break;
            case 2:
                transform.localPosition = new Vector3(0, -box.size.y / 2f, 0);
                break;
            case 1:
                transform.localPosition = new Vector3(-box.size.x / 2f, 0, 0);
                break;
            default:
                transform.localPosition = new Vector3(0, box.size.y / 2f, 0);
                break;
        }
	}
	
}
