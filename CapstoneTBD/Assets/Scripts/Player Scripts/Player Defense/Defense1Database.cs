using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Defense1Database : MonoBehaviour {

	PlayerStatistics stats;
	Rigidbody2D rb2d;

    void Awake()
    {
        stats = GetComponent<PlayerStatistics>();
		rb2d = GetComponent<Rigidbody2D>();
    }

	public void shield() {
		if (stats.facing) {
			Instantiate(stats.shield, new Vector3(transform.position.x - .1f, transform.position.y, 0), Quaternion.identity);
		}
		else
		{
			Instantiate(stats.shield, new Vector3(transform.position.x + .1f, transform.position.y, 0), Quaternion.identity);
		}
		
	}

    public float gravity;
	public void roll() {
		stats.nullActivity = true;
		stats.movementInvulnerable = true;
        gravity = rb2d.gravityScale;
        rb2d.gravityScale = 0;
		if (stats.facing) {
			rb2d.AddForce(new Vector2(200, rb2d.velocity.y));
		} else {
			rb2d.AddForce(new Vector2(-200, rb2d.velocity.y));
		}
		Invoke("resetVelocity", .3f);
		Invoke("movementDelay", .4f); 
	}

    //togle berserker mode in player stats and after 6 seconds toggle it off
    public void berserkerMode()
    {
        stats.berserkerMode = true;
        stats.damage += 5;
        stats.staminaRechargeRate = .1f;
        stats.staminaRechargeAmount = 3;
        Invoke("turnOffBerserkerMode", 6f);
    }

    //used to toggle off berserkermode in player stats
    public void turnOffBerserkerMode()
    {
        stats.berserkerMode = false;
        stats.damage -= 5;
        stats.staminaRechargeRate = .2f;
        stats.staminaRechargeAmount = 2;
    }

    //gives the player invincibility for 1 second
    public void invincible()
    {
        stats.defenseInvulnerable = true;
        Invoke("turnOffInvincible", 1f);
    }

    //turns invinsibility off
    public void turnOffInvincible()
    {
        stats.defenseInvulnerable = false;
    }

    //player becomes invulnerable for 3 seconds and unable to move
    //player is also given max health
    public void cocoon()
    {
        stats.nullActivity = true;
        stats.defenseInvulnerable = true;
        stats.heal((int)stats.maxHealth / 4);
        //invoke some kind of animation
        Invoke("endCocoon", 3f);
    }

    //helper to turn of zhonyas
    public void endCocoon()
    {
        stats.nullActivity = false;
        stats.defenseInvulnerable = false;
    }

    //damage done to player is cut in half and movementspeed is increased for 5 seconds
    public void ironSkin()
    {
        stats.damageReductionDivide = .5f;
        stats.walkSpeed *= 2;
        stats.runSpeed *= 2;
        stats.defaultWalkSpeed = stats.walkSpeed;
        stats.defaultRunSpeed = stats.runSpeed;
        Invoke("turnOffIronSkin", 5f);
    }

    //helper to return ironskin stats to normal
    public void turnOffIronSkin()
    {
        stats.damageReductionDivide = 1;
        stats.walkSpeed /= 2;
        stats.runSpeed /= 2;
        stats.defaultWalkSpeed = stats.walkSpeed;
        stats.defaultRunSpeed = stats.runSpeed;
    }

    //damage done to player is reduced by 25%, movespeed is increased for 10 seconds, + heal for a quarter of players max health
    public void steelSkin()
    {
        stats.damageReductionDivide = .25f;
        stats.walkSpeed *= 1.5f;
        stats.runSpeed *= 1.5f;
        stats.heal((int)(stats.maxHealth / 4));
        Invoke("turnOffSteelSkin", 5f);
    }

    //helper to turn off steelskin effect
    public void turnOffSteelSkin()
    {
        stats.damageReductionDivide = 1;
        stats.walkSpeed = stats.walkSpeed /= 1.5f;
        stats.runSpeed = stats.runSpeed /= 1.5f;
    }

    public void remedy()
    {
        stats.healthRegenAmount += 2;
        stats.healthRegenRate -= .3f;
        Invoke("turnOffRemedy", 7f);
    }

    public void turnOffRemedy()
    {
        stats.healthRegenAmount -= 2;
        stats.healthRegenRate += .3f;
    }

    //On name change, make sure to change any invokes
    public void movementDelay() {
		stats.nullActivity = false;
		stats.movementInvulnerable = false;
	}

	public void resetVelocity() {
		rb2d.velocity = new Vector3(0, rb2d.velocity.y, 0);
        rb2d.gravityScale = gravity;
	}
}
