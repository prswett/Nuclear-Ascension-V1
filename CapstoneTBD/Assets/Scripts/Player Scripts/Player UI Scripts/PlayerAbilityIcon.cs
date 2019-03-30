using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class PlayerAbilityIcon : MonoBehaviour
{

	PlayerStatistics stats;
	//Scripts for player abilities
	public Offense1 offense1script;
	public Offense2 offense2script;
	public Offense3 offense3script;
	public Defense1 defense1script;
	public Utility2 utility2script;

	//Ingame ability icons
    public Image offense1;
    public Image offense2;
	public Image offense3;
    public Image defense1;
	public Image utility1;
    public Image utility2;

	//Cooldowns
	public Image offense1cd;
	public Image offense2cd;
	public Image offense3cd;
	public Image defense1cd;
	public Image utility2cd;

    void Awake()
    {
		stats = GetComponentInParent<PlayerStatistics>();
	}

	void Update()
	{
		if (offense1script.timer != 0)
		{
			offense1cd.fillAmount = 1 - (Time.time - offense1script.timer) / stats.offense1cd;
		}
		if (offense2script.timer != 0)
		{
			offense2cd.fillAmount = 1 - (Time.time - offense2script.timer) / stats.offense2cd;
		}
		if (offense3script.timer != 0)
		{
			offense3cd.fillAmount = 1 - (Time.time - offense3script.timer) / stats.offense3cd;
		}
		if (defense1script.timer != 0)
		{
			defense1cd.fillAmount = 1 - (Time.time - defense1script.timer) / stats.defense1cd;
		}
		if (utility2script.timer != 0)
		{
			utility2cd.fillAmount = 1 - (Time.time - utility2script.timer) / stats.utility2cd;
		}
	}

    public void updateIcons()
	{
		updateOffense();
		updateDefense();
		updateJump();
		updateUtility();
	}

	public void updateOffense()
	{
		switch(stats.offense1)
		{
			case 4:
			offense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/GatlingBasic");
			offense2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/GatlingOverload");
			break;
			case 3:
			offense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/LaserBasic");
			offense2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/LaserSuperBeam");
			break;
			case 2:
			offense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RocketLauncherBasic");
			offense2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RocketLauncher5Spread");
			break;
			case 1:
			offense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RifleBasic");
			offense2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RiflePenetrateShot");
			break;
			default:
			offense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/PistolBasic");
			offense2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/PistolDoubleShot");
			break;
		}

		switch (stats.offense3)
		{
			default:
			offense3.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Offense/RocketHoming");
			break;
		}
	}

	public void updateDefense()
	{
		switch(stats.defense1)
		{
			case 7:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Remedy");
			break;
			case 6:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/SteelSkin");
			break;
			case 5:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/IronSkin");
			break;
			case 4:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Cocoon");
			break;
			case 3:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Invulnerability");
			break;
			case 2:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Berserk");
			break;
			case 1:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Shield");
			break;
			default:
			defense1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Defense/Roll");
			break;
		}
	}

	public void updateJump()
	{
		switch(stats.utility1)
		{
			case 3:
			utility1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/Jetpack");
			break;
			case 2:
			utility1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/JumpTeleport");
			break;
			case 1:
			utility1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/AirFloat");
			break;
			default:
			utility1.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/DoubleJump");
			break;
		}
	}

	public void updateUtility()
	{
		switch(stats.utility2) {
		case 3:
			utility2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/Turret");
			break;
			case 2:
			utility2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/EmergencyEscape");
			break;
			case 1:
			utility2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/Tether");
			break;
			default:
			utility2.sprite = Resources.Load<Sprite>("Sprites/PlayerUI/AbilityIcons/Utility/HealthPack");
			break;
		}
	}
}
