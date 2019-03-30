using System.Collections;
using System.Collections.Generic;
using UnityEngine.Audio;
using UnityEngine.UI;
using UnityEngine;

public class SettingsMenu : MonoBehaviour
{

    public AudioMixer audioMixer; //object that holds master volume bar

    public Dropdown resolutionDropdown; //dropdown menu object for resolutions

    public Dropdown qualityDropdown; //dropdown menu object for quality(low,medium,high etc...) 

    Resolution[] resolutions; //list of resolution availible to users computer

    private void Start()
    {
        //saves possible resolutions into array
        resolutions = Screen.resolutions;
        //clear all set options from the current dropdown
        resolutionDropdown.ClearOptions();

        //gets the default quality level that unity launches with and sets the dropdown bar to that value
        int defaultQualityLevel = QualitySettings.GetQualityLevel();
        qualityDropdown.value = defaultQualityLevel;


        int currentResolutionIndex = 0;

        //populate the string list with resoltions
        List<string> options = new List<string>();
        for(int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            //compare to make sure the two resoltutions are the same(unity can't compare 2 resolution objects for some reason)
            if(resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;
            }
        }

        //add list to the dropdown menu and refresh values to make sure they are set
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
    }

    //connects to the volume to the master volume slider
    public void setVolume(float volume)
    {
        audioMixer.SetFloat("Volume", volume);
        
    } 

    //set the resolution of the game based on the dropdown option selected
    public void setResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width,resolution.height, Screen.fullScreen);
    }

    //set the quality of the game based on the dropdown option selected 
    public void SetQuality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    //set to fullscreen or not full screen based on user toggle input
    public void SetFullscreen(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }
}
