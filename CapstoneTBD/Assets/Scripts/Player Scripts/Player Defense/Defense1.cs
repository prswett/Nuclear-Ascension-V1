using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense1 : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    Defense1Database database;

    public float timer;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Defense1Database>();
    }

    void Start()
    {
    }

    public void defend()
    {
        if (Time.time - timer >= stats.defense1cd || timer == 0)
        {
            timer = Time.time;
            switch (stats.defense1)
            {
                case 7:
                    database.remedy();
                    break;
                case 6:
                    database.steelSkin();
                    break;
                case 5:
                    database.ironSkin();
                    break;
                case 4:
                    database.cocoon();
                    break;
                case 3:
                    database.invincible();
                    break;
                case 2:
                    database.berserkerMode();
                    break;
                case 1:
                    database.shield();
                    break;
                default:
                    database.roll();
                    break;
            }
        }
    }
}
