using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BasicSpiderAi : MonoBehaviour {

    public GameObject[] players;
    public GameObject player; //player
    Vector3 targetPosition;

    public float MinDist; //min distance before enemy engages player/detects player
    public float specialSpeed; //speed that the enemy will chase the player
    public float randomValue;
    public float currentMarkPoint;

    public int randomMarkpoint;

    public bool playerBeingFollowed;
    public bool setRandomMarkpoint;

    EnemyController enemystuff; //grabbing bullet animations from controller (will be used later for better integration)

    public float left;
    public float right;
    public float top;
    public float bottom;

    public Vector3 mark1;
    public Vector3 mark2;
    public Vector3 mark3;
    public Vector3 mark4;
    public Vector3 mark5;
    public Vector3 mark6;
    public Vector3 mark7;
    public Vector3 mark8;
    public Vector3 mark9;
    public Vector3 mark10;

    // Use this for initialization
    void Start()
    {
        randomValue = Random.value;
        playerBeingFollowed = false;
        setRandomMarkpoint = false;
        currentMarkPoint = 5;
        randomMarkpoint = Random.Range(1, 10);

        players = GameObject.FindGameObjectsWithTag("Player");

        mark1 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark2 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark3 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark4 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark5 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark6 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark7 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark8 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark9 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
        mark10 = new Vector3(Random.Range(left, right), Random.Range(bottom, top));
    }

    float dist;
    float cooldown;
    // Update is called once per frame
    void Update()
    {
        foreach (GameObject trackedPlayer in players)
        {
            dist = Vector3.Distance(trackedPlayer.transform.position, transform.position);
            if (dist < MinDist)
            {
                player = trackedPlayer;
                break;
            }
            else
            {
                player = trackedPlayer;
            }
        }
        float step = specialSpeed * Time.deltaTime;

        if (dist < MinDist)
        {
            playerBeingFollowed = true;
            transform.position = Vector3.MoveTowards(transform.position, player.transform.position, step);
        }

        if (dist > MinDist)
        {
            playerBeingFollowed = false;
        }

        if (playerBeingFollowed == false)
        {
            switch (randomMarkpoint)
            {
                case 1:
                transform.position = Vector3.MoveTowards(transform.position, mark1, step);
                if (Vector3.Distance(transform.position, mark1) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 2:
                transform.position = Vector3.MoveTowards(transform.position, mark2, step);
                if (Vector3.Distance(transform.position, mark2) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 3:
                transform.position = Vector3.MoveTowards(transform.position, mark3, step);
                if (Vector3.Distance(transform.position, mark3) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 4:
                transform.position = Vector3.MoveTowards(transform.position, mark4, step);
                if (Vector3.Distance(transform.position, mark4) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 5:
                transform.position = Vector3.MoveTowards(transform.position, mark5, step);
                if (Vector3.Distance(transform.position, mark5) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 6:
                transform.position = Vector3.MoveTowards(transform.position, mark6, step);
                if (Vector3.Distance(transform.position, mark6) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 7:
                transform.position = Vector3.MoveTowards(transform.position, mark7, step);
                if (Vector3.Distance(transform.position, mark7) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 8:
                transform.position = Vector3.MoveTowards(transform.position, mark8, step);
                if (Vector3.Distance(transform.position, mark8) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 9:
                transform.position = Vector3.MoveTowards(transform.position, mark9, step);
                if (Vector3.Distance(transform.position, mark9) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
                case 10:
                transform.position = Vector3.MoveTowards(transform.position, mark10, step);
                if (Vector3.Distance(transform.position, mark10) < .02f && setRandomMarkpoint == false)
                {
                    setRandomMarkpoint = true;
                    cooldown = Random.Range(0f, 3f);
                    Invoke("getRandomMarkpoint", cooldown);
                }
                break;
            }
        }
    }

    public void getRandomMarkpoint()
    {
        randomMarkpoint = Random.Range(1, 10);
        setRandomMarkpoint = false;
    }

    public void setChaseSpeed(float cSpeed)
    {
        specialSpeed = cSpeed;
    }

    public void setAggroDistance(float aggro)
    {
        MinDist = aggro;
    }
}
