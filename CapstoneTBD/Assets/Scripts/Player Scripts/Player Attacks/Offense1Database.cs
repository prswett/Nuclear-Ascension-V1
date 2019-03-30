using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Offense1Database : MonoBehaviour
{

    PlayerStatistics stats;
    Rigidbody2D rb2d;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
        rb2d = GetComponent<Rigidbody2D>();
    }

    //Pistol shot
    public void pistolShot()
    {
        BulletController bullet = stats.bullet.GetComponent<BulletController>();
        bullet.damage = stats.calculateDamage(stats.damage / 3);
        if (!stats.facing)
        {
            bullet.velocityX = 3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    //Rifle shot
    public void rifleShot()
    {
        PenetrateBulletController bullet = stats.penetrateBullet.GetComponent<PenetrateBulletController>();
        bullet.damage = stats.calculateDamage(stats.damage * 1.5f);
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
    }

    public void rocketShot()
    {
        RocketBulletController bullet = stats.rocketBullet.GetComponent<RocketBulletController>();
        bullet.damage = stats.calculateDamage(stats.damage / 5);
        if (!stats.facing)
        {
            bullet.velocityX = 1;
            bullet.direction = 1;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -1;
            bullet.direction = -1;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    //Shoots a laser beam, prevents player from doing anythingw while the beam is active
    //Check lasercontroller for more details
    public void laserBeam()
    {
        LaserProjectileController laser = stats.laserbeamprojectile.GetComponent<LaserProjectileController>();
        laser.damage = stats.calculateDamage(stats.damage / 4);
        if (!stats.facing)
        {
            laser.velocityX = 3;
            Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
        else
        {
            laser.velocityX = -3;
            Instantiate(laser, new Vector3(transform.position.x, transform.position.y, 0), Quaternion.identity);
        }
    }

    //Gatling gun, shoots bullets at a random height
    public void gattlingGun()
    {
        BulletController bullet = stats.gatlingBullet.GetComponent<BulletController>();
        bullet.damage = stats.calculateDamage(stats.damage / 10);
        if (!stats.facing)
        {
            bullet.velocityX = 3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + Random.Range(-.01f, .01f), 0), Quaternion.identity);
        }
        else
        {
            bullet.velocityX = -3;
            Instantiate(bullet, new Vector3(transform.position.x, transform.position.y + Random.Range(-.01f, .01f), 0), Quaternion.identity);
        }
    }

}
