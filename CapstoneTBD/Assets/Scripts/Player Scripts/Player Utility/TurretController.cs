using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TurretController : MonoBehaviour
{

    public bool facing = false;
    public bool shootTarget = false;
    public bool lockedOn = false;
    public GameObject projectile;
    public float attackcd = 1f;
    public float lastAttacked = 0;
    public int damage;
    // Use this for initialization
    void Start()
    {
        Destroy(gameObject, 20f);
    }

    // Update is called once per frame
    void Update()
    {
        if (shootTarget)
        {
            attack();
        }
    }

    public void attack()
    {
        if (Time.time - lastAttacked >= attackcd || lastAttacked == 0)
        {
            BulletController bullet = projectile.GetComponent<BulletController>();
            bullet.damage = damage;
            if (!facing)
            {
                bullet.velocityX = 3;
                Instantiate(bullet, new Vector3(transform.position.x + .1f, transform.position.y, 0), Quaternion.identity);
            }
            else
            {
                bullet.velocityX = -3;
                Instantiate(bullet, new Vector3(transform.position.x - .1f, transform.position.y, 0), Quaternion.identity);
            }
			lastAttacked = Time.time;
        }
    }

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            if (other.transform.position.x < transform.position.x && !facing && !lockedOn)
            {
                flip();
            }
            else if (other.transform.position.x > transform.position.x && facing && !lockedOn)
            {
                flip();
            }
            shootTarget = true;
            lockedOn = true;
        }
    }

    void OnTriggerStay2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            
            if (other.transform.position.x < transform.position.x && !facing && !lockedOn)
            {
                flip();
            }
            else if (other.transform.position.x > transform.position.x && facing && !lockedOn)
            {
                flip();
            }
            shootTarget = true;
            lockedOn = true;
        }
    }

    void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Enemy") || other.CompareTag("Boss"))
        {
            shootTarget = false;
            lockedOn = false;
        }
    }

    public void flip()
    {
        facing = !facing;
        Vector3 charscale = transform.localScale;
        charscale.x *= -1;
        transform.localScale = charscale;
    }
}
