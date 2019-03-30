using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraFollow : MonoBehaviour
{
    public Transform Target;

    //Transforms the camera postion to be equal to the character postion
    //camera will follow character per frame update
    public void Update()
    {
        transform.position = new Vector3(
            Target.transform.position.x,
            Target.transform.position.y,
            transform.position.z
        );
    }
}