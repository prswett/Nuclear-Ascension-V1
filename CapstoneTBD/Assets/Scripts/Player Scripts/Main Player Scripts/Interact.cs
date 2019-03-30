using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Interact : MonoBehaviour
{

    public bool npc;
    public bool exitVehicle;

    // Use this for initialization
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.E))
        {
            interact();
        }
    }

    public void interact()
    {
        if (npc == true)
        {
            //Do something
        }
        else if (exitVehicle == true)
        {
            Car temp = GameObject.FindGameObjectWithTag("exitVehicle").GetComponent<Car>();
            SceneManager.LoadScene(temp.sceneNumber);
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("npc"))
        {
            npc = true;
        }
        if (other.gameObject.CompareTag("exitVehicle"))
        {
            exitVehicle = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("npc"))
        {
            npc = false;
        }
        if (other.gameObject.CompareTag("exitVehicle"))
        {
            exitVehicle = false;
        }
    }
}
