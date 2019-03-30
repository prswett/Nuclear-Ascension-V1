using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyStats : MonoBehaviour {

	public float maxHealth;
	public int damage;

	void Awake()
	{
		maxHealth = GlobalEnemyInfo.getHP();
		damage = GlobalEnemyInfo.getDamage();
	}

}
