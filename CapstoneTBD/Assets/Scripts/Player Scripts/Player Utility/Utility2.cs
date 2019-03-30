using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Utility2 : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;
    Utility2Database database;

    public float timer;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
        database = GetComponent<Utility2Database>();
    }

    void Update()
    {
    }

    public void utility()
    {
        if (Time.time - timer >= stats.utility2cd || timer == 0)
        {
            timer = Time.time;
            switch (stats.utility2)
            {
                case 3:
                    database.spawnTurret();
                    break;
                case 2:
                    database.emergencyEscape();
                    break;
                case 1:
                    if (!database.activatedTether)
                    {
                        database.specialTether();
                        timer -= stats.utility2cd;
                    }
                    else
                    {
                        database.tetherHelper();
                    }
                    break;
                default:
                    database.healthPack();
                    break;
            }
        }
    }
}
