using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class FinalBoss2ndPhase : MonoBehaviour
{


    public GameObject[] players; //player
    public GameObject player;

    public int damage;

    public bool abilityCD;
    public bool intro;
    public bool preIntro;
    public bool platformSwapCD;
    public BossHealth health;

    public int currentPlatform;

    BossStats stats;
    EnemyController enemystuff; //grabbing bullet animations from controller (will be used later for better integration)

    public GameObject poisonCloud;
    public GameObject poisonBuff;
    public GameObject gasGhost;
    public GameObject poisonGernade;
    public GameObject nuke;


    public Transform platformLocation1;
    public Transform platformLocation2;
    public Transform platformLocation3;
    public Transform platformLocation4;
    public Transform platformLocation5;
    public Transform platformLocation6;
    public Transform platformLocation7;
    public Transform platformLocation8;
    public Transform platformLocation9;
    public Transform platformLocation10;
    public Transform platformLocation11;
    public Transform platformLocation12;
    public Transform platformLocation13;

    public Transform gasGhostRight;
    public Transform gasGhostLeft;

    void Awake()
    {
        health = GetComponentInChildren<BossHealth>();
        stats = GetComponentInChildren<BossStats>();
    }
    // Use this for initialization
    void Start()
    {
        enemystuff = GetComponent<EnemyController>();
        players = GameObject.FindGameObjectsWithTag("Player");
        abilityCD = false;
        intro = true;
        preIntro = true;
        platformSwapCD = false;
        currentPlatform = 0;
        damage = stats.damage;
    }

    // Update is called once per frame
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
            player = players[Random.Range(0, players.Length)];
            abilityCD = true;
            int abilityDecider = Random.Range(0, 7);
            int randomTime = 0;
            switch (abilityDecider)
            {
                case 6:
                    buff();
                    randomTime = Random.Range(1, 2);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 2f);
                    break;
                case 5:
                    poisonClouds();
                    randomTime = Random.Range(4, 7);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 4f);
                    break;
                case 4:
                    gernadeToss();
                    randomTime = Random.Range(4, 7);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 4f);
                    break;
                case 2:
                    deathCloud();
                    randomTime = Random.Range(4, 7);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 4f);
                    break;
                case 1:
                    nuclearCombustion();
                    randomTime = Random.Range(4, 7);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 4f);
                    break;
                default:
                    toxicGrenadeBarrage();
                    randomTime = Random.Range(4, 7);
                    Invoke("resetCD", (float)randomTime);
                    makeBossTakeDamage();
                    Invoke("makeBossImmuneToDamage", 4f);
                    break;
            }
        }

        if (intro == false)
        {
            if (platformSwapCD == false)
            {

                int randomPlatform = Random.Range(0, 13);
                int randomTimeDefault = Random.Range(6, 10);

                if (randomPlatform != currentPlatform)
                {
                    currentPlatform = randomPlatform;
                    switch (randomPlatform)
                    {
                        case 12:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation13.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 11:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation12.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 10:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation11.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 9:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation10.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 8:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation9.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 7:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation8.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 6:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation7.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 5:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation6.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 4:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation5.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 3:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation4.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 2:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation3.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        case 1:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation2.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;

                        default:
                            platformSwapCD = true;
                            //some kind of teleportation animation
                            transform.position = platformLocation1.position;
                            Invoke("resetSwapCD", (float)randomTimeDefault);
                            break;
                    }
                }
            }
        }

    }

    //lobs grenades in all directions from middle of current platform
    public void toxicGrenadeBarrage()
    {
        PoisonGernade grenade = poisonGernade.GetComponent<PoisonGernade>();
        grenade.damage = damage;

        grenade.velocityX = 100;
        grenade.velocityY = 20;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 40;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 60;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 80;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 100;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityX = -100;
        grenade.velocityY = 20;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 40;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 60;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 80;
        Instantiate(grenade, transform.position, Quaternion.identity);
        grenade.velocityY = 100;
        Instantiate(grenade, transform.position, Quaternion.identity);
    }

    //large aoe nuclear explosion 
    public void nuclearCombustion()
    {
        PoisonNuke poisonNuke = nuke.GetComponent<PoisonNuke>();
        poisonNuke.damage = damage;

        Instantiate(nuke, transform.position, Quaternion.identity);
    }

    //cloud chase 
    public void deathCloud()
    {
        GasGhost ghost = gasGhost.GetComponent<GasGhost>();
        ghost.damage = damage;
        player = players[Random.Range(0, players.Length)];
        ghost.target = player.transform;
        Instantiate(ghost, gasGhostLeft.position, Quaternion.identity);
        player = players[Random.Range(0, players.Length)];
        ghost.target = player.transform;
        Instantiate(ghost, gasGhostRight.position, Quaternion.identity);

    }

    public void gernadeToss()
    {
        PoisonGernade grenade = poisonGernade.GetComponent<PoisonGernade>();
        grenade.damage = damage;
        if (player.transform.position.x < transform.position.x)
        {
            grenade.velocityX = -100;
            grenade.velocityY = 20;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 40;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 60;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 80;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 100;
            Instantiate(grenade, transform.position, Quaternion.identity);
        }
        else
        {
            grenade.velocityX = 100;
            grenade.velocityY = 20;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 40;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 60;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 80;
            Instantiate(grenade, transform.position, Quaternion.identity);
            grenade.velocityY = 100;
            Instantiate(grenade, transform.position, Quaternion.identity);
        }
    }

    public void poisonClouds()
    {
        PoisonCloud cloud = poisonCloud.GetComponent<PoisonCloud>();
        cloud.damage = damage;
        int roll = 0;
        for (int i = 0; i < 3; i++)
        {
            roll = Random.Range(1, 14);
            switch (roll)
            {
                case 13:
                    Instantiate(cloud, platformLocation13.position, Quaternion.identity);
                    break;
                case 12:
                    Instantiate(cloud, platformLocation12.position, Quaternion.identity);
                    break;
                case 11:
                    Instantiate(cloud, platformLocation11.position, Quaternion.identity);
                    break;
                case 10:
                    Instantiate(cloud, platformLocation10.position, Quaternion.identity);
                    break;
                case 9:
                    Instantiate(cloud, platformLocation9.position, Quaternion.identity);
                    break;
                case 8:
                    Instantiate(cloud, platformLocation8.position, Quaternion.identity);
                    break;
                case 7:
                    Instantiate(cloud, platformLocation7.position, Quaternion.identity);
                    break;
                case 6:
                    Instantiate(cloud, platformLocation6.position, Quaternion.identity);
                    break;
                case 5:
                    Instantiate(cloud, platformLocation5.position, Quaternion.identity);
                    break;
                case 4:
                    Instantiate(cloud, platformLocation4.position, Quaternion.identity);
                    break;
                case 3:
                    Instantiate(cloud, platformLocation3.position, Quaternion.identity);
                    break;
                case 2:
                    Instantiate(cloud, platformLocation2.position, Quaternion.identity);
                    break;
                case 1:
                    Instantiate(cloud, platformLocation1.position, Quaternion.identity);
                    break;
            }
        }
    }

    public void buff()
    {
        PoisonBuff poisonbuff = poisonBuff.GetComponent<PoisonBuff>();
        poisonbuff.boss = GetComponent<Transform>();

        health.health *= 1.1f;
        damage = (int)(float)(damage * 1.1f);
        Instantiate(poisonBuff, transform.position, Quaternion.identity);
    }

    public void endIntro()
    {
        intro = false;
    }

    public void resetCD()
    {
        abilityCD = false;
    }

    public void resetSwapCD()
    {
        platformSwapCD = false;
    }

    public void makeBossImmuneToDamage()
    {
        health.invulnerability = true;
    }

    public void makeBossTakeDamage()
    {
        health.invulnerability = false;
    }

}
