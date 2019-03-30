using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerStatistics : MonoBehaviour
{

    //Player Stats
    public float health;
    public float healthRegen;
    public float healthRegenRate;
    public int healthRegenAmount;
    public float maxHealth; //max health player is allowed to have
    public int damage;
    public float criticalChance;
    public float criticalDamage;
    public float jumpSpeed;
    public float runSpeed;
    public float walkSpeed;
    public float stamina;
    public float maxStamina;
    public float staminaRecharge;
    public float staminaRechargeRate;
    public int staminaRechargeAmount;
    public float gravity;


    public float damageToBeTaken; //damage the player is about to take from the enemy 
    public float damageReductionDivide; //damage divided by this variable is new reduced damage player should take

    //Player Abilities
    public int offense1;
    public int offense2;
    public int offense3;
    public int defense1;
    public int utility1;
    public int utility2;
    //Player Ability cooldowns
    public float offense1cd;
    public float offense2cd;
    public float offense3cd;
    public float defense1cd;
    public float utility2cd;

    //Player movement variables
    public bool facing = false;
    public bool movementShift = false;
    public float groundCheckRadius;

    //Player status effects
    public bool movementInvulnerable = false;
    public bool utilityInvulnerable = false;
    public bool berserkerMode = false;
    public bool defenseInvulnerable = false;
    public bool nullActivity = false;

    //Player personalized objects
    public GameObject bullet;
    public GameObject penetrateBullet;
    public GameObject rocketBullet;
    public GameObject homingRocket;
    public GameObject laserbeam;
    public GameObject laserbeamprojectile;
    public GameObject gatlingBullet;
    public GameObject shield;
    public GameObject teleportCheck;
    public GameObject turret;


    //Default values used for player reset
    public float defaultWalkSpeed;
    public float defaultRunSpeed;
    public float defaultJumpSpeed;


    //Values for enhanced skills / changed skills
    public int offense1Skill;
    public int offense2Skill;
    public int offense3Skill;
    public int defense1Skill;
    public int utility1Skill;
    public int utility2Skill;
    public int[] offense1Enhance;
    public int[] offense2Enhance;
    public int[] offense3Enhance;
    public int[] defense1Enhance;
    public int[] utility1Enhance;
    public int[] utility2Enhance;

    public static PlayerStatistics Instance;
    void Awake()
    {
        if (Instance == null)
        {
            DontDestroyOnLoad(gameObject);
            Instance = this;
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
    }

    //Initializes values at their default
    void Start()
    {
        damage = 20;
        criticalChance = 0;
        criticalDamage = 2;
        maxHealth = 300;
        health = maxHealth;
        healthRegenAmount = 1;
        healthRegenRate = 2f;
        jumpSpeed = 3;
        runSpeed = 2f;
        walkSpeed = 1f;
        maxStamina = 100;
        stamina = maxStamina;
        staminaRechargeRate = .2f;
        staminaRechargeAmount = 2;
        gravity = 1;
        damageReductionDivide = 1;

        offense1cd = .3f;
        offense2cd = 5f;
        offense3cd = 1f;
        defense1cd = 3f;
        utility2cd = 5f;

        groundCheckRadius = 0.02f;

        //Defaults
        defaultWalkSpeed = walkSpeed;
        defaultRunSpeed = runSpeed;
        defaultJumpSpeed = jumpSpeed;

        offense1Enhance = new int[5];
        offense2Enhance = new int[5];
        offense3Enhance = new int[5];
        defense1Enhance = new int[5];
        utility1Enhance = new int[5];
        utility2Enhance = new int[5];
    }

    public int calculateDamage(float retDamage)
    {
        int critical = Random.Range(0, 100);
        if (critical < criticalChance)
        {
            retDamage *= criticalDamage;
        }
        return (int)retDamage;
    }

    public void heal(int input)
    {
        if (maxHealth - health > input)
        {
            health += input;
        }
        else
        {
            health = maxHealth;
        }
    }

    public void takeDamage(float damage)
    {
        if (movementInvulnerable || defenseInvulnerable || utilityInvulnerable)
        {
            return;
        }
        damage = (int)(damage * damageReductionDivide);
        damageToBeTaken = damage;
        health = health - damageToBeTaken;
        if (berserkerMode)
        {
            if (health <= 0)
            {
                health = 1;
            }
        }
        else
        {
            if (health <= 0)
            {
                health = 0;
                SceneManager.LoadScene(0);
                Destroy(gameObject);
            }
        }
    }

    void Update()
    {
        if (stamina < maxStamina)
        {
            if (Time.time - staminaRecharge > staminaRechargeRate || staminaRecharge == 0)
            {
                if (maxStamina - stamina < staminaRechargeAmount)
                {
                    stamina = maxStamina;
                    staminaRecharge = Time.time;
                }
                else
                {
                    stamina += staminaRechargeAmount;
                    staminaRecharge = Time.time;
                }
            }
        }

        if (health < maxHealth)
        {
            if (Time.time - healthRegen > healthRegenRate || healthRegen == 0)
            {
                heal(healthRegenAmount);
                healthRegen = Time.time;
            }
        }
    }

    public void applyDefaults()
    {
        walkSpeed = defaultWalkSpeed;
        runSpeed = defaultRunSpeed;
        jumpSpeed = defaultJumpSpeed;
    }

    //Checks the current players stats to make sure they are valid
    //after getting new relics
    public void statCheck()
    {
        if (maxHealth < 1)
        {
            maxHealth = 1;
        }
        if (healthRegenRate < .5)
        {
            healthRegenRate = .5f;
        }
        if (healthRegenAmount < 1)
        {
            healthRegenAmount = 1;
        }
        if (damage < 0)
        {
            damage = 0;
        }
        if (criticalChance < 0)
        {
            criticalChance = 0;
        }
        if (criticalDamage < 1)
        {
            criticalDamage = 1;
        }
        if (jumpSpeed < .1f)
        {
            jumpSpeed = .1f;
        }
        if (runSpeed < .1f)
        {
            runSpeed = .1f;
        }
        if (walkSpeed < .1f)
        {
            walkSpeed = .1f;
        }
        if (maxStamina < 1)
        {
            maxStamina = 1;
        }
        if (staminaRechargeRate < 1)
        {
            staminaRechargeRate = 1;
        }
        if (staminaRechargeAmount < 1)
        {
            staminaRechargeAmount = 1;
        }
        if (offense1cd < .1f)
        {
            offense1cd = .1f;
        }
        if (offense2cd < 1f)
        {
            offense2cd = 1f;
        }
        if (offense3cd < 1f)
        {
            offense3cd = 1f;
        }
        if (defense1cd < 1f)
        {
            defense1cd = 1f;
        }
        if (utility2cd < 1f)
        {
            utility2cd = 1f;
        }
    }
}
