using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss1stPhase : MonoBehaviour
{

    public GameObject[] players; //player
    public GameObject player;

    public bool abilityCD;
    public bool intro;
    public bool preIntro;

    BossStats stats;
    public BossHealth health;


    //Boss gameobjects
    public GameObject homingMissile;
    public GameObject nukeRain;
    public GameObject carpetBomb;
    public GameObject laser;
    public GameObject turret;
    public GameObject drone;


    //Horizontal player detector booleans
    public bool horizontal1 = false;
    public bool horizontal2 = false;
    public bool horizontal3 = false;
    public bool horizontal4 = false;
    public bool horizontal5 = false;
    public bool horizontal6 = false;
    public bool horizontal7 = false;
    public Transform horizontalLocation1;
    public Transform horizontalLocation2;
    public Transform horizontalLocation3;
    public Transform horizontalLocation4;
    public Transform horizontalLocation5;
    public Transform horizontalLocation6;
    public Transform horizontalLocation7;



    //Bombing Locations
    public Transform verticalLocation1;
    public Transform verticalLocation2;
    public Transform verticalLocation3;
    public Transform verticalLocation4;
    public Transform verticalLocation5;
    public Transform verticalLocation6;
    public Transform verticalLocation7;
    public Transform verticalLocation8;
    public Transform verticalLocation9;
    public Transform verticalLocation10;
    public Transform verticalLocation11;
    public Transform verticalLocation12;
    public Transform verticalLocation13;
    public Transform verticalLocation14;
    public Transform verticalLocation15;
    public Transform verticalLocation16;
    public Transform verticalLocation17;
    public Transform verticalLocation18;
    public Transform verticalLocation19;
    public Transform verticalLocation20;
    public Transform verticalLocation21;
    public Transform verticalLocation22;
    public Transform verticalLocation23;
    public Transform verticalLocation24;
    public Transform verticalLocation25;
    public Transform verticalLocation26;
    public Transform verticalLocation27;
    public Transform verticalLocation28;

    public int damage;
    void Awake()
    {
        stats = GetComponentInChildren<BossStats>();
        health = GetComponentInChildren<BossHealth>();
    }


    // Use this for initialization
    void Start()
    {
        damage = stats.damage;
        players = GameObject.FindGameObjectsWithTag("Player");
        abilityCD = false;
        intro = true;
        preIntro = true;
    }

    int randomTime;
    void Update()
    {

        if (intro == true && preIntro == true)
        {
            preIntro = false;
            health.invulnerability = true;
            Invoke("endIntro", 7f);
        }

        if (abilityCD == false && intro == false)
        {
            abilityCD = true;
            int abilityDecider = Random.Range(0, 5);
            randomTime = Random.Range(2, 5);
            switch (abilityDecider)
            {
                case 4:
                    turretGun();
                    Invoke("resetCD", (float)randomTime);
                    break;
                case 3:
                    CarpetBomb();
                    Invoke("resetCD", (float)randomTime);
                    break;
                case 2:
                    overChargeBeam();
                    Invoke("resetCD", (float)randomTime);
                    break;
                case 1:
                    RainNukes();
                    Invoke("resetCD", (float)randomTime);
                    break;
                default:
                    homingNukes();
                    Invoke("resetCD", (float)randomTime);
                    break;
            }
        }

    }

    //shoots out missles that will home towards player(can be shot down and explode on platforms) maybe destroy after some x seconds?
    public void homingNukes()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        BossHomingMissile bullet = homingMissile.GetComponent<BossHomingMissile>();
        bullet.target = players[Random.Range(0, players.Length)].transform;
        bullet.damage = damage;
        if (horizontal1)
        {
            Instantiate(homingMissile, horizontalLocation1.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation2.position, Quaternion.identity);
        }
        else if (horizontal2)
        {
            Instantiate(homingMissile, horizontalLocation2.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation4.position, Quaternion.identity);
        }
        else if (horizontal3)
        {
            Instantiate(homingMissile, horizontalLocation3.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation6.position, Quaternion.identity);
        }
        else if (horizontal4)
        {
            Instantiate(homingMissile, horizontalLocation4.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation1.position, Quaternion.identity);
        }
        else if (horizontal5)
        {
            Instantiate(homingMissile, horizontalLocation5.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation7.position, Quaternion.identity);
        }
        else if (horizontal6)
        {
            Instantiate(homingMissile, horizontalLocation6.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation2.position, Quaternion.identity);
        }
        else
        {
            Instantiate(homingMissile, horizontalLocation7.position, Quaternion.identity);
            Instantiate(homingMissile, horizontalLocation3.position, Quaternion.identity);
        }
    }

    //rains small nukes on player from top of the stage
    public void RainNukes()
    {
        NukeDown bullet = nukeRain.GetComponent<NukeDown>();
        bullet.damage = damage;
        Instantiate(nukeRain, verticalLocation1.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation3.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation5.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation7.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation9.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation11.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation13.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation15.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation17.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation19.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation21.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation23.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation25.position, Quaternion.identity);
        Instantiate(nukeRain, verticalLocation27.position, Quaternion.identity);
    }

    public void CarpetBomb()
    {
        CarpetBomb bullet = carpetBomb.GetComponent<CarpetBomb>();
        bullet.damage = damage;
        Instantiate(carpetBomb, verticalLocation1.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation2.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation3.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation4.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation5.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation6.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation7.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation8.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation9.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation10.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation11.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation12.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation13.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation14.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation15.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation16.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation17.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation18.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation19.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation20.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation21.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation22.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation23.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation24.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation25.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation26.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation27.position, Quaternion.identity);
        Instantiate(carpetBomb, verticalLocation28.position, Quaternion.identity);
    }

    //channels laser beam from boss
    public void overChargeBeam()
    {
        FireLaserBeam bullet = laser.GetComponent<FireLaserBeam>();
        bullet.damage = damage;
        if (horizontal1)
        {
            Instantiate(laser, horizontalLocation1.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation7.position, Quaternion.identity);
        }
        else if (horizontal2)
        {
            Instantiate(laser, horizontalLocation2.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation6.position, Quaternion.identity);
        }
        else if (horizontal3)
        {
            Instantiate(laser, horizontalLocation3.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation5.position, Quaternion.identity);
        }
        else if (horizontal4)
        {
            Instantiate(laser, horizontalLocation4.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation5.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation3.position, Quaternion.identity);
        }
        else if (horizontal5)
        {
            Instantiate(laser, horizontalLocation5.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation3.position, Quaternion.identity);
        }
        else if (horizontal6)
        {
            Instantiate(laser, horizontalLocation2.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation6.position, Quaternion.identity);
        }
        else
        {
            Instantiate(laser, horizontalLocation1.position, Quaternion.identity);
            Instantiate(laser, horizontalLocation7.position, Quaternion.identity);
        }
    }

    int count = 0;
    public void turretGun()
    {
        if (count < 15)
        {
            shootBullet();
            Invoke("turretGun", .05f);
            count++;
        }
        else
        {
            count = 0;
        }
    }
    public void shootBullet()
    {
        BossPistolBullet bullet = turret.GetComponent<BossPistolBullet>();
        bullet.damage = damage;
        bullet.velocityX = -2;
        if (horizontal1)
        {
            Instantiate(turret, horizontalLocation1.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation2.position, Quaternion.identity);
        }
        else if (horizontal2)
        {
            Instantiate(turret, horizontalLocation2.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation3.position, Quaternion.identity);
        }
        else if (horizontal3)
        {
            Instantiate(turret, horizontalLocation3.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation4.position, Quaternion.identity);
        }
        else if (horizontal4)
        {
            Instantiate(turret, horizontalLocation4.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation5.position, Quaternion.identity);
        }
        else if (horizontal5)
        {
            Instantiate(turret, horizontalLocation5.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation6.position, Quaternion.identity);
        }
        else if (horizontal6)
        {
            Instantiate(turret, horizontalLocation6.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation7.position, Quaternion.identity);
        }
        else
        {
            Instantiate(turret, horizontalLocation6.position, Quaternion.identity);
            Instantiate(turret, horizontalLocation7.position, Quaternion.identity);
        }
    }

    public void spawnDrones()
    {
        players = GameObject.FindGameObjectsWithTag("Player");
        for (int i = 0; i < Random.Range(1, 5); i++)
        {
            randomDroneLocation();
        }
    }

    public Transform droneSpawn1;
    public Transform droneSpawn2;
    public Transform droneSpawn3;
    public Transform droneSpawn4;
    public void randomDroneLocation()
    {
        int roll = Random.Range(1, 5);
        BossDrone droneScript = drone.GetComponent<BossDrone>();
        droneScript.player = players[Random.Range(0, players.Length)].transform;
        while (droneScript.player == null)
        {
            droneScript.player = players[Random.Range(0, players.Length)].transform;
        }
        switch (roll)
        {
            case 4:
            Instantiate(drone, droneSpawn4.position, Quaternion.identity);
            break;
            case 3:
            Instantiate(drone, droneSpawn3.position, Quaternion.identity);
            break;
            case 2:
            Instantiate(drone, droneSpawn2.position, Quaternion.identity);
            break;
            case 1:
            Instantiate(drone, droneSpawn1.position, Quaternion.identity);
            break;
        }
    }

    public void endIntro()
    {
        intro = false;
        health.invulnerability = false;
    }

    public void resetCD()
    {
        abilityCD = false;
    }

}
