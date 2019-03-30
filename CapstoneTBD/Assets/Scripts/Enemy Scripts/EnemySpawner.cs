using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    public int spawnTime;
    public float floatSpawnTime;
    public bool spawn = false;
    public GameObject enemyPistol; //pistol enemy prefab
    public GameObject enemySniper;
    public GameObject enemyRocket;
    public GameObject enemyLaser;
    public GameObject enemyFlyingSwarmer; //flyingswarmer prefab
    public GameObject enemyBomber; // flying bomber prefab
    public GameObject spiderEnemy; //spider prefab
    public GameObject bossDrone;


    public bool spawnPistol = false;
    public bool spawnSniper = false;
    public bool spawnRocket = false;
    public bool spawnLaser = false;
    public bool spawnFlyingSwarmer = false;
    public bool spawnBomber = false;
    public bool spawnSpider = false;

    public float chaseSpeed;

    //dimensions of the spawn box for resizing
    public Transform left;
    public Transform right;
    public Transform top;
    public Transform bottom;

    public Transform leftPosition;
    public Transform rightPosition;
    public Transform topPosition;
    public Transform bottomPosition;

    public int spawnCap;
    public int spawnCD;
    GameObject[] enemies;

    //public BasicEnemy myBasicEnemy;
    // Use this for initialization
    void Start()
    {
        floatSpawnTime = (float)spawnTime;
        InvokeRepeating("spawnEnemy", 0, floatSpawnTime);
    }

    int spawnAmount = 0;
    void spawnEnemy()
    {
        if (spawn)
        {
            enemies = GameObject.FindGameObjectsWithTag("Enemy");
            if (spawnPistol)
            {
                if (canSpawn())
                {
                    spawnPistolEnemy();
                    spawnAmount++;
                }
            }
            if (spawnSniper)
            {
                if (canSpawn())
                {
                    spawnSniperEnemy();
                    spawnAmount++;
                }
            }
            if (spawnRocket)
            {
                if (canSpawn())
                {
                    spawnRocketEnemy();
                    spawnAmount++;
                }
            }
            if (spawnLaser)
            {
                if (canSpawn())
                {
                    spawnLaserEnemy();
                    spawnAmount++;
                }
            }
            if (spawnFlyingSwarmer)
            {
                if (canSpawn())
                {
                    spawnFlyingEnemy();
                    spawnAmount++;
                }
            }
            if (spawnBomber)
            {
                if (canSpawn())
                {
                    spawnBombingEnemy();
                    spawnAmount++;
                }
            }

            if (spawnAmount >= spawnCap)
            {
                Invoke("resetSpawn", GlobalEnemyInfo.EnemySpawnCD());
            }
        }
    }

    public bool canSpawn()
    {
        if (spawnAmount < spawnCap && enemies.Length < GlobalEnemyInfo.MaxEnemySpawn())
        {
            return true;
        }
        return false;
    }

    public void resetSpawn()
    {
        spawnAmount = 0;
    }

    float x;
    float y;
    public Vector3 calculateSpawn()
    {
        x = Random.Range(leftPosition.transform.position.x, rightPosition.transform.position.x);
        y = Random.Range(bottomPosition.transform.position.y, topPosition.transform.position.y);
        return new Vector3(x, y);
    }
    //bombing enemy 
    public void spawnBombingEnemy()
    {
        BombingFlyingEnemy enemyScript = enemyBomber.GetComponent<BombingFlyingEnemy>();
        enemyScript.left = left.position.x;
        enemyScript.right = right.position.x;
        enemyScript.top = top.position.y;
        enemyScript.bottom = bottom.position.y;
        enemyScript.MinDist = Random.Range(.3f, 1.3f);
        enemyScript.speed = 1f;
        //create enemy object
        Vector3 position = calculateSpawn();
        Instantiate(enemyBomber, position, Quaternion.identity);
    }


    /// //////////////////////////////////////////////////////////////////////////////
    public void spawnPistolEnemy()
    {
        Vector3 position = calculateSpawn();
        PistolEnemy enemy = enemyPistol.GetComponent<PistolEnemy>();
        enemy.MinDist = Random.Range(.2f, .6f);
        enemy.leftMarker = left.position.x;
        enemy.rightMarker = right.position.x;

        Instantiate(enemyPistol, position, Quaternion.identity);
    }

    public void spawnSniperEnemy()
    {
        Vector3 position = calculateSpawn();
        SniperEnemy enemy = enemySniper.GetComponent<SniperEnemy>();
        enemy.MinDist = Random.Range(2f, 6f);
        enemy.leftMarker = left.position.x;
        enemy.rightMarker = right.position.x;

        Instantiate(enemySniper, position, Quaternion.identity);
    }

    public void spawnRocketEnemy()
    {
        Vector3 position = calculateSpawn();
        RocketEnemy enemy = enemyRocket.GetComponent<RocketEnemy>();
        enemy.MinDist = Random.Range(1f, 4f);
        enemy.leftMarker = left.position.x;
        enemy.rightMarker = right.position.x;

        Instantiate(enemyRocket, position, Quaternion.identity);
    }

    public void spawnLaserEnemy()
    {
        Vector3 position = calculateSpawn();
        LaserEnemy enemy = enemyLaser.GetComponent<LaserEnemy>();
        enemy.MinDist = Random.Range(1f, 4f);
        enemy.leftMarker = left.position.x;
        enemy.rightMarker = right.position.x;

        Instantiate(enemyLaser, position, Quaternion.identity);
    }

    public void spawnFlyingEnemy()
    {
        BasicFlyingEnemy enemyScript = enemyFlyingSwarmer.GetComponent<BasicFlyingEnemy>();
        enemyScript.speed = 1;
        enemyScript.left = left.position.x;
        enemyScript.right = right.position.x;
        enemyScript.top = top.position.y;
        enemyScript.bottom = bottom.position.y;
        enemyScript.MinDist = Random.Range(.2f, .5f);
        //spawn enemy
        Vector3 position = calculateSpawn();
        Instantiate(enemyFlyingSwarmer, position, Quaternion.identity);
    }
}
