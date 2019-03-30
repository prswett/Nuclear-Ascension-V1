using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense1 : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    Offense1Database database;

    //Used for gatling gun
    public float gatlingcd;

    public float timer;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Offense1Database>();
    }

    void Start()
    {
        gatlingcd = .1f;
    }

    void Update()
    {

    }

    public void attack()
    {
        if (Time.time - timer >= stats.offense1cd || timer == 0)
        {
            switch (stats.offense1)
            {
                case 4:
                    //Gatling attack, make sure to change the Time.time stuff in future
                    timer = Time.time - gatlingcd;
                    database.gattlingGun();
                    break;
                case 3:
                    timer = Time.time;
                    database.laserBeam();
                    break;
                case 2:
                    //Rocket attack
                    timer = Time.time;
                    database.rocketShot();
                    break;
                case 1:
                    //Rifle attack
                    timer = Time.time;
                    database.rifleShot();
                    break;
                default:
                    //Pistol attack
                    timer = Time.time;
                    database.pistolShot();
                    break;
            }
        }
    }
}
