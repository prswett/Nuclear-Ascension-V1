using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility2Database : MonoBehaviour {

	PlayerStatistics stats;
    Rigidbody2D rb2d;
    Utility2 utility2;
	public Vector2 tetherVector;// keeps the position to tether back to
    public bool activatedTether;
    public bool utility2Activated;
    public GameObject tether;

    //list of positions for time travel method
    public List<Vector2> listOfPosition = new List<Vector2>();

	void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        utility2 = GetComponent<Utility2>();
    }
	void Start () {
		listOfPosition.Add(rb2d.transform.position);
        listOfPosition[0] = rb2d.transform.position;
        activatedTether = false;
        utility2Activated = false;
	}

	void Update () {
        //calls the method that records the players position every frame
		trackPlayerPosition();
	}

	
    //takes the user back in time by 1 second
    public void emergencyEscape()
    {
        rb2d.transform.position = listOfPosition[0];
    }

    //keeps track of the player position x seconds ago updating every frame
    public void trackPlayerPosition()
    {
        Vector2 tempVector = rb2d.transform.position;
        StartCoroutine(MyFunction(tempVector, 1f));

    }

    //waits x seconds before storing the value so you have the correct value
    IEnumerator MyFunction(Vector2 myVector, float delayTime)
    {
        yield return new WaitForSeconds(delayTime);
        listOfPosition[0] = myVector;
    }

    //method to tether to a spot and return to it after x seconds 
    public void specialTether()
    {
        tetherVector = rb2d.transform.position;
        activatedTether = true;
        Instantiate(tether, transform.position, Quaternion.identity);
        Invoke("tetherHelper", 3f);
    }

    //take player to tether spot and reset tether in 6f
    public void tetherHelper()
    {
        if (activatedTether == true)
        {
            utility2Activated = true;
            rb2d.transform.position = tetherVector;
            utility2.timer = Time.time;
        }
    }

	public void spawnTurret()
    {
        TurretController turretcontroller = stats.turret.GetComponent<TurretController>();
        turretcontroller.damage = stats.calculateDamage(stats.damage / 4);
        Instantiate(stats.turret, transform.position, Quaternion.identity);
    }

    //Heal 10% of max hp
    public void healthPack()
    {
        int heal = (int)stats.maxHealth / 4;
        stats.heal(heal);
    }
}
