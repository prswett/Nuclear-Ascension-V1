using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour
{

    PlayerStatistics stats;

    Movement movement;
    Interact interact;
    Offense1 offense1;
    Offense2 offense2;
    Defense1 defense1;
    Utility1 utility1;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        movement = GetComponent<Movement>();
        interact = GetComponent<Interact>();
        offense1 = GetComponent<Offense1>();
        offense2 = GetComponent<Offense2>();
        defense1 = GetComponent<Defense1>();
        utility1 = GetComponent<Utility1>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (!stats.nullActivity)
        {
            //Used for player running
            if (Input.GetKey(KeyCode.LeftShift))
            {
                movement.run(true);
            }
            if (Input.GetKeyUp(KeyCode.LeftShift))
            {
                movement.run(false);
            }

            //Checking for interaction
            if (Input.GetKeyDown(KeyCode.F))
            {
                interact.interact();
            }

            //Basic attack
            if (Input.GetKey(KeyCode.J))
            {
                offense1.attack();
            }

            //Special attack
            if (Input.GetKeyDown(KeyCode.K))
            {
                offense2.attack();
            }

            //Defense ability
            if (Input.GetKeyDown(KeyCode.L))
            {
                defense1.defend();
            }

            //Utility ability
            if (Input.GetKeyDown(KeyCode.Space))
            {
                utility1.utility();
            }
            //Resets effects from utility
            if (Input.GetKeyUp(KeyCode.Space))
            {
                utility1.jumpReset();
            }

            //To be used for utility abiltiies
            //like turrets and health packs
            if (Input.GetKeyDown(KeyCode.I))
            {
                utility1.utilityTool();
            }
        }

    }

    void FixedUpdate()
    {
        if (!stats.nullActivity && !stats.movementShift)
        {
            //Used for player movement (left right)
            if (Input.GetKey(KeyCode.A))
            {
                movement.left();
            }

            if (Input.GetKey(KeyCode.D))
            {
                movement.right();
            }

            //Activates utility method. This method
            //activates movement tools like jetpack
            if (Input.GetKey(KeyCode.I))
            {
                utility1.utilityMovementTool();
            }

            if (Input.GetKeyUp(KeyCode.I))
            {
                utility1.utilityReset();
            }
        }
    }
}
