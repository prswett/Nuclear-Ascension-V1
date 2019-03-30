using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BossPlayerDetector : MonoBehaviour {

	public int location;
	FinalBoss1stPhase boss;
	void Awake()
	{
		boss = GetComponentInParent<FinalBoss1stPhase>();
	}

	void OnTriggerEnter2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			switch(location)
			{
				case 6:
					boss.horizontal7 = true;
				break;
				case 5:
					boss.horizontal6 = true;
				break;
				case 4:
					boss.horizontal5 = true;
				break;
				case 3:
					boss.horizontal4 = true;
				break;
				case 2:
					boss.horizontal3 = true;
				break;
				case 1:
					boss.horizontal2 = true;
				break;
				default:
					boss.horizontal1 = true;
				break;
			}
		}
	}

	void OnTriggerExit2D(Collider2D other)
	{
		if (other.CompareTag("Player"))
		{
			switch(location)
			{
				case 6:
					boss.horizontal7 = false;
				break;
				case 5:
					boss.horizontal6 = false;
				break;
				case 4:
					boss.horizontal5 = false;
				break;
				case 3:
					boss.horizontal4 = false;
				break;
				case 2:
					boss.horizontal3 = false;
				break;
				case 1:
					boss.horizontal2 = false;
				break;
				default:
					boss.horizontal1 = false;
				break;
			}
		}
	}
}
