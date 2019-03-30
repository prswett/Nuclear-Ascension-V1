using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerAbilityChooser : MonoBehaviour
{

    PlayerStatistics stats;
    public Text text;
    public GameObject chooseAbilityPanel;
    public ChooseAbilityButton chooseability;
    public PlayerAbilityIcon abilityicon;
    void Awake()
    {
        stats = GetComponentInParent<PlayerStatistics>();
        chooseability = GetComponentInChildren<ChooseAbilityButton>();
    }

    void Start()
    {
        Time.timeScale = 0;
        stats.nullActivity = true;
    }

    public void close()
    {
        Time.timeScale = 1;
        stats.nullActivity = false;
        abilityicon.updateIcons();
        Destroy(chooseAbilityPanel.gameObject);
        SceneManager.LoadScene(1);
    }

    public void chooseOffense1(int input)
    {
        stats.offense1 = input;
        stats.offense2 = input;
        chooseability.changeOffenseIcon(input);
        loadOffense1Text(input);
        switch (input)
        {
            case 4:
                stats.offense1cd = .3f;
                stats.offense2cd = 20f;
                break;
            case 3:
                stats.offense1cd = 2f;
                stats.offense2cd = 40f;
                break;
            case 2:
                stats.offense1cd = 1f;
                stats.offense2cd = 40f;
                break;
            case 1:
                stats.offense1cd = .5f;
                stats.offense2cd = 10f;
                break;
            default:
                stats.offense1cd = .3f;
                stats.offense2cd = 5f;
                break;
        }
    }

    public void loadOffense1Text(int input)
    {
        switch (input)
        {
            case 4:
                text.text = "Gatling Gun \nBasic Attack: Shoot from a machine gun at a fast pace \nSpecial Attack: Overload your machine gun to shoot at an even faster pace";
                break;
            case 3:
                text.text = "Laser Gun \nBasic Attack: Shoot a laser beam that penetrates enemies and walls \nSpecial Attack: Stand still and fire a large laser that pierces";
                break;
            case 2:
                text.text = "Rocket Launcher \nBasic Attack: Shoot a rocket that explodes on contact \nSpecial Attack: Fire 5 rockets that spread upward. One rocket will always fly forward";
                break;
            case 1:
                text.text = "Rifle \nBasic Attack: Fire a fast bullet that does damage to one enemy \nSpecial Attack: Fire a fast bullet that penetrates and does enhanced damage";
                break;
            default:
                text.text = "Pistol \nBasic Attack: Fire a bullet that does damage to one enemy \nSpecial Attack: Fire two bullets that do enhanced damage and have a larger chance to crit";
                break;
        }
    }

    public void chooseOffense3(int input)
    {
        stats.offense3 = input;
        chooseability.changeOffense3Icon(input);
        loadOffense3Text(input);
        switch (input)
        {
            default:
                stats.offense3cd = 1f;
                break;
        }
    }

    public void loadOffense3Text(int input)
    {
        switch (input)
        {
            default:
                text.text = "Homing Rocket \nShoot a rocket upwards that homes on any enemy that is directly above you";
                break;
        }
    }

    public void chooseDefense1(int input)
    {
        stats.defense1 = input;
        chooseability.changeDefenseIcon(input);
        loadDefense1Text(input);
        switch (input)
        {
            case 7:
                stats.defense1cd = 20f;
                break;
            case 6:
                stats.defense1cd = 30f;
                break;
            case 5:
                stats.defense1cd = 25f;
                break;
            case 4:
                stats.defense1cd = 45f;
                break;
            case 3:
                stats.defense1cd = 60f;
                break;
            case 2:
                stats.defense1cd = 60f;
                break;
            case 1:
                stats.defense1cd = 10f;
                break;
            default:
                stats.defense1cd = 10f;
                break;
        }
    }

    public void loadDefense1Text(int input)
    {
        switch (input)
        {
            case 7:
                text.text = "Remedy \nDrink a remedy that increases your health regeneration and regeneration rate for a set duration";
                break;
            case 6:
                text.text = "Steel Skin \nCover yourself in steel for a period of time to decrease damage taken by 25%, increase movement speed, and heal yourself";
                break;
            case 5:
                text.text = "Iron Skin \nCover yourself in iron for a period of time to decrease damage taken by 50% and increase movement speed";
                break;
            case 4:
                text.text = "Cocoon \nCover yourself in a cocoon to become invulnerable and heal for 25% of your max hp. You cannot preform any action during the duration of this skill";
                break;
            case 3:
                text.text = "Invulnerability \nBecome invulnerable for a period of time. You will take no damage for the duration of the skill. You can perform actions during this skill";
                break;
            case 2:
                text.text = "Berserk \nBecome enraged, increasing your damage, stamina regeneration rate and amount. You cannot die during the duration of this skill (Your hp will not fall below 1)";
                break;
            case 1:
                text.text = "Shield \nTake our a shield that blocks enemy projectiles in front of you. You can perform all actions while the shield is active";
                break;
            default:
                text.text = "Roll \nRoll in the opposite direction you are facing. You are invulnerable while you roll backwards. You can roll through enemies";
                break;
        }
    }

    public void chooseUtility1(int input)
    {
        stats.utility1 = input;
        chooseability.changeJumpIcon(input);
        loadUtility1Text(input);
    }

    public void loadUtility1Text(int input)
    {
        switch (input)
        {
            case 3:
                text.text = "Jet Pack \nReplace your jump with a jetpack that lets you maneuver in the air so long as you have the energy to do so.";
                break;
            case 2:
                text.text = "Jump Teleport \nActivate in the air to teleport a certain distance in the direction you are facing. Cannot go through walls.";
                break;
            case 1:
                text.text = "Air float \nActivate in the air to float on a cloud and move side to side while you have energe";
                break;
            default:
                text.text = "Double Jump \nGain an extra jump in the air";
                break;
        }
    }

    public void chooseUtility2(int input)
    {
        stats.utility2 = input;
        chooseability.changeUtilityIcon(input);
        loadUtility2Text(input);
        switch (input)
        {
            case 3:
                stats.utility2cd = 40f;
                break;
            case 2:
                stats.utility2cd = 20f;
                break;
            case 1:
                stats.utility2cd = 20f;
                break;
            default:
                stats.utility2cd = 30f;
                break;
        }
    }

    public void loadUtility2Text(int input)
    {
        switch (input)
        {
            case 3:
                text.text = "Spawn Turret \nSpawn a turret that shoots enemies when they come within a certain range. Turrets last 20 seconds";
                break;
            case 2:
                text.text = "Emergency Escape \nActivate to return to your location 4 seconds ago.";
                break;
            case 1:
                text.text = "Tether \nMark a location and return to that location after a period of time. You can press the utility hotkey again to return early";
                break;
            default:
                text.text = "Health Pack \nUse a health pack to restore 25% of your max health";
                break;
        }
    }
}