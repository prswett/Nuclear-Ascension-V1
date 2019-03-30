using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense2 : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    Offense2Database database;

    public float timer;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Offense2Database>();
    }

    void Start()
    {
    }

    void Update()
    {
    }

    public void attack() {
        if (Time.time - timer >= stats.offense2cd || timer == 0)
        {
            switch (stats.offense2)
            {
                case 4:
                    timer = Time.time;
                    database.gatlingOverload();
                    break;
                case 3:
                    bool temp = database.laserBeam();
                    if (temp == true)
                    {
                        timer = Time.time;
                    }
                    break;
                case 2:
                    timer = Time.time;
                    database.rocketShot();
                    break;
                case 1:
                    timer = Time.time;
                    database.rifleShot();
                    break;
                default:
                    timer = Time.time;
                    database.pistolShot();
                    break;
            }
        }
    }
}
