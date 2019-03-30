using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossStats : MonoBehaviour {

	public float maxHealth;
	public int damage;

	void Awake()
	{
		maxHealth = GlobalEnemyInfo.getBossHP();
		damage = GlobalEnemyInfo.getBossDamage();
	}
}
