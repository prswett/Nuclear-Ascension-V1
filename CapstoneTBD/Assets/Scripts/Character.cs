using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Character : MonoBehaviour {

    public float Speed = 3f; //not really relevant(need to play around with time delta a bit more)
    public bool IsMoving { get; private set; } //used to keep the player from imputting more commands while already trying to complete one

    public Pin CurrentPin { get; private set; }//current pint
    private Pin _targetPin; //target pin
    private MapManager _mapManager; //map manager object


    public void Initialise(MapManager mapManager, Pin startPin)
    {
        //passes in the mapmanager object and sets the first pin on the map to the start pin
        _mapManager = mapManager;
        SetCurrentPin(startPin);
    }

    private void Update()
    {
        //if no target then exit
        if (_targetPin == null) return;

        // Get the characters current position and the targets position
        Vector2 currentPosition = transform.position;
        Vector2 targetPosition = _targetPin.transform.position;

        // If the character isn't that close to the target move closer
        transform.position = Vector2.MoveTowards(currentPosition, targetPosition, Time.deltaTime * Speed);
        
        //when the target has reached the destination then set your current pin to the pin you just arrived at 
        if (Vector2.Distance(currentPosition, targetPosition) < .02f)
        {
            SetCurrentPin(_targetPin);
        }
        
    }

    //sets a target ping which will triger the update function and sets the player to moving
    public void MoveToPin(Pin pin)
    {
        _targetPin = pin;
        IsMoving = true;
    }

    //set the current pin to the target pin once you have arrived and update the gui
    public void SetCurrentPin(Pin pin)
    {
        CurrentPin = pin;
        _targetPin = null;
        transform.position = pin.transform.position;
        IsMoving = false;
        _mapManager.UpdateGui();
    }
}

