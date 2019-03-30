using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossHealth : MonoBehaviour
{

    public BossStats stats;
    public float health;
    public float timer;
    public int type;

    public bool invulnerability = false;

    public GameObject FinalBoss2;
    public GameObject FinalBoss3;
	public Transform spawnPosition;

    void Awake()
    {
        stats = GetComponent<BossStats>();
    }
    void Start()
    {
        health = stats.maxHealth;
    }

    public void takeDamage(float damage)
    {
        if (!invulnerability)
        {
            //Maybe some defense calculated here or something
            health -= damage;

            if (health <= 0)
            {
                Destroy();
            }
        }
    }

    public void takeDamageWithCD(float damage)
    {
        if (!invulnerability)
        {
            if (Time.time - timer >= 2f || timer == 0)
            {
                health -= damage;
                timer = Time.time;
            }

            if (health <= 0)
            {
                Destroy();
            }
        }
    }

    public void takeDamageWithCDInput(float damage, float time)
    {
        if (!invulnerability)
        {
            if (Time.time - timer >= time || timer == 0)
            {
                health -= damage;
                timer = Time.time;
            }

            if (health <= 0)
            {
                Destroy();
            }
        }
    }

    void Destroy()
    {
        switch (type)
        {
            case 2:
                Destroy(transform.parent.gameObject);
				Instantiate(FinalBoss3, transform.position, Quaternion.identity);
                break;
            case 1:
                Destroy(transform.parent.gameObject);
				Instantiate(FinalBoss2, spawnPosition.position, Quaternion.identity);
                break;
            default:
                Destroy(transform.parent.gameObject);
                break;
        }
    }
}
