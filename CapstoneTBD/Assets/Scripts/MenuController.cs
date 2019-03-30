using System.Collections;
using System.Collections.Generic;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MenuController : MonoBehaviour
{

    public GameObject optionPanel; //panel for the menu (the parent for all ui buttons and text)
    public GameObject RelicCanvas; // the panel displaying the relics
    public GameObject RelicUI; // the gameObject manipulating the canvas
    public GameObject Camera;
    RelicDisplay relicdisplay;
    private bool RelicStart = true;

    void Awake()
    {
        relicdisplay = RelicUI.GetComponent<RelicDisplay>();
    }
    //deativate the panel when the game starts
    void Start()
    {
        optionPanel.SetActive(false);
    }

    // check for user input once per frame
    void Update()
    {
        CheckForInput();
        // initial start for relic display to be off
    }

    //checks for user input
    private void CheckForInput()
    {

        //if the user presses the escape button
        //set the panel to active and pause the game
        if (Input.GetKeyUp(KeyCode.Escape))
        {
			if (Time.timeScale == 0) {
				optionPanel.SetActive (false);
				Time.timeScale = 1;
			} else {
				optionPanel.SetActive (true);
				Time.timeScale = 0;
			}
        }
        // toggle visibility of canvas display
        if (Input.GetKeyDown(KeyCode.P))
        {
            if (RelicCanvas.activeInHierarchy)
            {
                RelicCanvas.SetActive(false);
                Time.timeScale = 1;
            }
            else
            {
                Time.timeScale = 0;
                RelicCanvas.SetActive(true);
            }
        }
    }

    //retarts the level and unpauses the game
    public void restartLevelButton()
    {
        Destroy(transform.parent.gameObject);
        SceneManager.LoadScene(0);
    }

    //sets the menu Panel to deactivate and unpauses the game
    public void resumeGameBtn()
    {
        optionPanel.SetActive(false);
        Time.timeScale = 1;
    }

    //exits the game(only works in the build version, doesn't actually effect the game during compiler testing)
    public void exitGameBtn()
    {
        Application.Quit();
    }
}

