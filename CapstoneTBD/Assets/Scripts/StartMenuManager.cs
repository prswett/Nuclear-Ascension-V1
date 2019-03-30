using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class StartMenuManager : MonoBehaviour {

    public GameObject startMenu; //object representing the first start menu panel
    public GameObject settingsMenu; // object representing the panel that holds settings

    //sets start menu to active and deactivates setting menu
    void Start()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }


    //starts a new game from the first designated scene
    public void newGameButton()
    {
        SceneManager.LoadScene("Menu Test");
    }

    public void loadGameButton()
    {
        //place holder for hansel to do whatever he needs to do
    }

    //deactivate the start screen and activate setting screen
    public void settingsButton()
    {
        startMenu.SetActive(false);
        settingsMenu.SetActive(true);
    }

    //exits the game(only works in the build version, doesn't actually effect the game during compiler testing)
    public void exitGameBtn()
    {
        Application.Quit();
    }

    //deactivates settings panel and activates start menu panel
    public void backToStartMenuButton()
    {
        startMenu.SetActive(true);
        settingsMenu.SetActive(false);
    }
}
