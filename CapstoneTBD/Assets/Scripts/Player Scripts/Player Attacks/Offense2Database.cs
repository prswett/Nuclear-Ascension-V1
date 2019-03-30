using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense2Database : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    public void pistolShot()
    {
        BulletController bullet = stats.bullet.GetComponent<BulletController>();
        bullet.damage = stats.calculateDamage(stats.damage);
        if (!stats.facing)
        {
            bullet.velocityX = 3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + .02f, 0), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - .02f, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + .02f, 0), Quaternion.identity);
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y - .02f, 0), Quaternion.identity);
        }
    }

    //Add penetration + damage boost
    public void rifleShot()
    {
        PenetrateBulletController bullet = stats.penetrateBullet.GetComponent<PenetrateBulletController>();
        bullet.damage = stats.calculateDamage(stats.damage * 2.5f);
        bullet.pierce = true;
        if (!stats.facing)
        {
            bullet.velocityX = 6;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -6;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        bullet.pierce = false;
    }

    public void rocketShot()
    {
        RocketBulletController bullet = stats.rocketBullet.GetComponent<RocketBulletController>();
        bullet.damage = stats.calculateDamage(stats.damage / 5);
        if (!stats.facing)
        {
            for (int i = 0; i < 5; i++)
            {
                bullet.velocityX = 1;
                bullet.velocityY = .2f * i;
                bullet.direction = 1;
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
        }
        else
        {
            for (int i = 0; i < 5; i++)
            {
                bullet.velocityX = -1;
                bullet.velocityY = .2f * i;
                bullet.direction = -1;
                Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
        }
        bullet.velocityY = 0;
    }

    public bool laserBeam()
    {
        if (rb2d.velocity.y == 0)
        {
            LaserController laser = stats.laserbeam.GetComponent<LaserController>();
            laser.damage = stats.calculateDamage(stats.damage / 2);
            if (!stats.facing)
            {
                Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
            }
            return true;
        }
        else
        {
            return false;
        }
    }

    //Decreases basic attack cool down for 2 seconds
    public void gatlingOverload()
    {
        Offense1 offense1 = GetComponent<Offense1>();
        offense1.gatlingcd = .25f;
        Invoke("gatlingOverloadHelper", 2f);
    }

    public void gatlingOverloadHelper()
    {
        Offense1 offense1 = GetComponent<Offense1>();
        offense1.gatlingcd = .1f;
    }
}
