using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GlobalEnemyInfo : MonoBehaviour {

	static int baseHP;
	static int baseDamage;

	void Start () {
		baseHP = 30;
		baseDamage = 5;
	}

	public static int MaxEnemySpawn()
	{
		int temp = 10;
		temp += (RelicL.relicPicked / 2);
		return temp;
	}

	public static float EnemySpawnCD()
	{
		float temp = 5f;
		temp -= (RelicL.relicPicked * .1f);
		if (temp < 0)
		{
			temp = 0;
		}
		return temp;
	}

	static float scaleValue;
	static float relicScale;
	public static float getHP()
	{
		scaleValue = (int)(Time.timeSinceLevelLoad % 4) + 1;
		relicScale = (int)(RelicL.relicPicked / 2) * .1f + 1;
		return (float)(int)(baseHP * ((scaleValue / 10f) + relicScale / 4f));
	}

	public static int getDamage()
	{
		scaleValue = (int)(Time.timeSinceLevelLoad % 4) + 1;
		relicScale = (int)(RelicL.relicPicked / 2) * .1f + 1;
		return (int)(baseDamage * ((scaleValue / 10f) + relicScale));
	}

	public static float getBossHP()
	{
		relicScale = (int)(RelicL.relicPicked + 1) * .3f;
		return (float)(int)(1000 * relicScale);
	}

	public static int getBossDamage()
	{
		relicScale = (int)(RelicL.relicPicked + 1) * .3f;
		return (int)(20 * relicScale);
	}
}
