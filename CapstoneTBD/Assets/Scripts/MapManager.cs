using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine;

public class MapManager : MonoBehaviour
{
    public Character Character; //character
    public Text SelectedLevelText; //text at the top
    public bool badStage; //bool used to track is the user is trying to access a non existant stage

    public Pin stage1;
    public Pin stage2;
    public Pin stage3;
    public Pin stage4;
    public Pin stage5;
    Pin[] stages = new Pin[5]; //list of stages

    private int currentStage; //keeps track of the current stage number... first stage is 0 etc...
     
    private void Start()
    {
        //hardcoding stage info for testing
        stage1.SceneToLoad = "California";
        stage2.SceneToLoad = "Hawaii";
        stage3.SceneToLoad = "Kansas";
        stage4.SceneToLoad = "Virginia";
        stage5.SceneToLoad = "New York";
        stage1.Stagenumber = 0;
        stage2.Stagenumber = 1;
        stage3.Stagenumber = 2; 
        stage4.Stagenumber = 3;
        stage5.Stagenumber = 4;
        stages[0] = stage1;
        stages[1] = stage2;
        stages[2] = stage3;
        stages[3] = stage4;
        stages[4] = stage5;
        currentStage = 0;
 
        // Pass a ref and default the player Starting Pin
        Character.Initialise(this, stages[0]);


        SelectedLevelText.text = "Current Level: " + Character.CurrentPin.SceneToLoad;

    }

    private void Update()
    {
        // Only check input when character is stopped
        if (Character.IsMoving) return;
        // First thing to do is try get the player input
        CheckForInput();
    }

    private void CheckForInput()
    {
        //triggers when up key is pressed
        if (Input.GetKeyUp(KeyCode.UpArrow))
        {
            //load the current scene that the character is hovering over
            SceneManager.LoadScene(Character.CurrentPin.SceneToLoad);
        }
        //trigger when down key is pressed
        else if (Input.GetKeyUp(KeyCode.DownArrow))
        {
            //checks if the user input takes you to a valid stage or if they are trying to go beyond the last stage or before the first stage
            Pin tempPin = getPreviousPin();
            if (badStage == false)
            {
                Character.MoveToPin(tempPin);
            }
        }
        //trigger when left key is pressed
        else if (Input.GetKeyDown(KeyCode.LeftArrow))
        {
            //checks if the user input takes you to a valid stage or if they are trying to go beyond the last stage or before the first stage
            Pin tempPin = getPreviousPin();
            if (badStage == false)
            {
                Character.MoveToPin(tempPin);
            }
        }
        //trigger when right key is pressed
        else if (Input.GetKeyDown(KeyCode.RightArrow))
        {
            //checks if the user input takes you to a valid stage or if they are trying to go beyond the last stage or before the first stage
            Pin tempPin = getNextPin();
            if (badStage == false)
            {
                Character.MoveToPin(tempPin);
            }
        }
    }

    //returns the next availible stage
    public Pin getNextPin()
    {
        if (currentStage >-1 && currentStage <= stages.Length - 2)
        {
            //checks if valid stage and returns the stage/pin object
            currentStage = currentStage + 1;
            badStage = false;
            return stages[currentStage];
        }
        //same as returning null/ all we care about in this case is setting the boolean because the returned pin/stage is never used
        badStage = true;
        return stages[currentStage];
    }

    //returns the stage before the current stage
    public Pin getPreviousPin()
    {
        if (currentStage > 0 && currentStage <= stages.Length - 1)
        {
            //checks if valid stage and returns the stage/pin object
            currentStage = currentStage - 1;
            badStage = false;
            return stages[currentStage];
        }
        //same as returning null/ all we care about in this case is setting the boolean because the returned pin/stage is never used
        badStage = true;
        return stages[currentStage];
    }

    //update stage text at the top of the screen when the character reaches a new stage
	public void UpdateGui()
    {
        SelectedLevelText.text = "Current Level: " + Character.CurrentPin.SceneToLoad;
    }
    
}
