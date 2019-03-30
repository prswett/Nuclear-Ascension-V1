using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerController : MonoBehaviour
{

    PlayerStatistics stats;
    Animator anim;

    Movement movement;
    Interact interact;
    Offense1 offense1;
    Offense2 offense2;
    Offense3 offense3;
    Defense1 defense1;
    Utility1 utility1;
    Utility2 utility2;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        anim = GetComponent<Animator>();
        movement = GetComponent<Movement>();
        interact = GetComponent<Interact>();
        offense1 = GetComponent<Offense1>();
        offense2 = GetComponent<Offense2>();
        offense3 = GetComponent<Offense3>();
        defense1 = GetComponent<Defense1>();
        utility1 = GetComponent<Utility1>();
        utility2 = GetComponent<Utility2>();
    }
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKey(KeyCode.R))
        {
            SceneManager.LoadScene(0);
        }
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
            if (Input.GetKey(KeyCode.W) && Input.GetKey(KeyCode.J))
            {
                offense3.attack();
            }
            else if (Input.GetKey(KeyCode.J))
            {
                offense1.attack();
            }

            //Special attack
            if (Input.GetKey(KeyCode.K))
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
                utility2.utility();
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
                anim.SetBool("Walking", true);
            }

            if (Input.GetKey(KeyCode.D))
            {
                movement.right();
                anim.SetBool("Walking", true);
            }

            if (Input.GetKeyUp(KeyCode.D))
            {
                anim.SetBool("Walking", false);
            }

            if (Input.GetKeyUp(KeyCode.A))
            {
                anim.SetBool("Walking", false);
            }
            //Activates utility method. This method
            //activates movement tools like jetpack  
            if (Input.GetKey(KeyCode.Space))
            {
                utility1.utilityMovementTool();
            }
        }
    }
}
