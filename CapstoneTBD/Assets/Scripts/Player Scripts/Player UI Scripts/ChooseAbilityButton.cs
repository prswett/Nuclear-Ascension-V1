using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ChooseAbilityButton : MonoBehaviour
{
    public Image offenseChosenIcon;
    public Image offense3ChosenIcon;
    public Image defenseChosenIcon;
    public Image jumpChosenIcon;
    public Image utilityChosenIcon;

    //Offense buttons
    public Button pistol;
    public Button Rifle;
    public Button RocketLauncher;
    public Button Laser;
    public Button Gatling;
    public Button RocketHoming;
    //Defense buttons
    public Button Roll;
    public Button Shield;
    public Button BerserkerMode;
    public Button Invincible;
    public Button Cocoon;
    public Button IronSkin;
    public Button SteelSkin;
    public Button Remedy;
    //Jump buttons
    public Button DoubleJump;
    public Button AirFloat;
    public Button JumpTeleport;
    public Button Jetpack;
    //Utility buttons
    public Button HealthPack;
    public Button Tether;
    public Button EmergencyExit;
    public Button Turret;
    void Start()
    {

    }

    void Update()
    {

    }

    public void changeOffenseIcon(int input)
    {
        switch (input)
        {
            case 4:
                offenseChosenIcon.transform.position = Gatling.transform.position;
                break;
            case 3:
                offenseChosenIcon.transform.position = Laser.transform.position;
                break;
            case 2:
                offenseChosenIcon.transform.position = RocketLauncher.transform.position;
                break;
            case 1:
                offenseChosenIcon.transform.position = Rifle.transform.position;
                break;
            default:
                offenseChosenIcon.transform.position = pistol.transform.position;
                break;
        }
    }

    public void changeOffense3Icon(int input)
    {
        switch (input)
        {
            default:
                offense3ChosenIcon.transform.position = RocketHoming.transform.position;
                break;
        }
    }

    public void changeDefenseIcon(int input)
    {
        switch (input)
        {
            case 7:
                defenseChosenIcon.transform.position = Remedy.transform.position;
                break;
            case 6:
                defenseChosenIcon.transform.position = SteelSkin.transform.position;
                break;
            case 5:
                defenseChosenIcon.transform.position = IronSkin.transform.position;
                break;
            case 4:
                defenseChosenIcon.transform.position = Cocoon.transform.position;
                break;
            case 3:
                defenseChosenIcon.transform.position = Invincible.transform.position;
                break;
            case 2:
                defenseChosenIcon.transform.position = BerserkerMode.transform.position;
                break;
            case 1:
                defenseChosenIcon.transform.position = Shield.transform.position;
                break;
            default:
                defenseChosenIcon.transform.position = Roll.transform.position;
                break;
        }
    }

    public void changeJumpIcon(int input)
    {
        switch (input)
        {
            case 3:
                jumpChosenIcon.transform.position = Jetpack.transform.position;
                break;
            case 2:
                jumpChosenIcon.transform.position = JumpTeleport.transform.position;
                break;
            case 1:
                jumpChosenIcon.transform.position = AirFloat.transform.position;
                break;
            default:
                jumpChosenIcon.transform.position = DoubleJump.transform.position;
                break;
        }
    }

    public void changeUtilityIcon(int input)
    {
        switch (input)
        {
            case 3:
                utilityChosenIcon.transform.position = Turret.transform.position;
                break;
            case 2:
                utilityChosenIcon.transform.position = EmergencyExit.transform.position;
                break;
            case 1:
                utilityChosenIcon.transform.position = Tether.transform.position;
                break;
            default:
                utilityChosenIcon.transform.position = HealthPack.transform.position;
                break;
        }
    }
}
