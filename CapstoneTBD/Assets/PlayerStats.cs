using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerStats : MonoBehaviour {

	public float currentHealth;
	public float maxHealth;
	public float healthTimer;
	public float healthRegenRate;
	public float healthRegenAmount;

	//Health regeneration methods
	IEnumerator healthRegen()
	{
		while (true)
		{
			//Healing every period of time
			if (Time.time - healthTimer > healthRegenRate || healthTimer == 0)
			{
				if (currentHealth < maxHealth - healthRegenAmount)
				{
					currentHealth += healthRegenAmount;
				}
				else
				{
					currentHealth = maxHealth;
				}
			}
		}
	}

	//
	public static PlayerStats Instance;
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

	void Start () {
		StartCoroutine (healthRegen());

	}
	
	
	void Update () {
		
	}
}
