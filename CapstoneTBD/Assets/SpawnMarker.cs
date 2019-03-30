using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SpawnMarker : MonoBehaviour
{

    // Use this for initialization
    public int position;
    void Awake()
    {
        BoxCollider2D box = GetComponentInParent<BoxCollider2D>();
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
