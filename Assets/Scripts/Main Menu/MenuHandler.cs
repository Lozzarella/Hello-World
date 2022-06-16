using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour//Class to manage main menu canvas system
{
    public Transform playerTrans;



    #region Main Menu System
   
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }//function to change between scenes

    public void LoadContinue()
    {
        SaveLoadHandler.loadPath = PlayerPrefs.GetString("loadPath", SavePlayerData.path1);
    }//function to load what game was last saved and played

    public void LoadSlotOne()//function to load the game saved in save slot one
    {
        SaveLoadHandler.loadPath = SavePlayerData.path1;
        PlayerPrefs.SetString("loadPath", SavePlayerData.path1);
    }
    public void LoadSlotTwo()//function to load the game saved in save slot two
    {
        SaveLoadHandler.loadPath = SavePlayerData.path2;
        PlayerPrefs.SetString("loadPath", SavePlayerData.path2);
    }
    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }//to quit the game

    #endregion

    #region Audio
    public AudioMixer masterAudio;
    public string currentSlider;
    public Slider tempSlider;
    
    public void GetSlider (Slider slider)
    {
        tempSlider = slider;
    }

    public void MuteToggle(bool isMuted)
    {
        if (isMuted)
        {
            masterAudio.SetFloat(currentSlider, -80);
            tempSlider.interactable = false;
            PlayerPrefs.SetInt(currentSlider + "mute", 1);
        }
        else
        {
            masterAudio.SetFloat(currentSlider, tempSlider.value);
            tempSlider.interactable = true;
            PlayerPrefs.SetInt(currentSlider + "mute", 0);
        }

        
    }

    public void CurrentSlider(string sliderName)
    {
        currentSlider = sliderName;
    }
    
    public void ChangeVolume (float volume)
    {
        masterAudio.SetFloat(currentSlider, volume);
        PlayerPrefs.SetFloat(currentSlider, volume);
    }


    #endregion
    #region Save and Load User Settings
    //sliders
    [SerializeField] Slider sliderMasterVol;
    [SerializeField] Slider sliderMusicVol;
    [SerializeField] Slider sliderSfxVol;
    [SerializeField] Toggle muteMaster;
 
    void LoadSettings()
    {
        float theSavedSetting;
        theSavedSetting = PlayerPrefs.GetFloat("masterVolume", 80f);
        masterAudio.SetFloat("masterVolume", theSavedSetting);
        sliderMasterVol.value = theSavedSetting;
        bool muted = PlayerPrefs.GetInt(currentSlider + "mute", 0) == 0 ? false: true;
        muteMaster.isOn = muted;


        theSavedSetting = PlayerPrefs.GetFloat("musicVolume", 80f);
        masterAudio.SetFloat("musicVolume", theSavedSetting);
        sliderMusicVol.value = theSavedSetting;

        theSavedSetting = PlayerPrefs.GetFloat("sfxVolume", 80f);
        masterAudio.SetFloat("sfxVolume", theSavedSetting);
        sliderSfxVol.value = theSavedSetting;

        
    }

    #endregion

    #region Quality

    public void Quality(int qualityIndex)
    {
        QualitySettings.SetQualityLevel(qualityIndex);
    }

    #endregion

    #region Resolution
    public Resolution[] resolutions;
    public Dropdown resDropdown;

    public void FullScreenToggle(bool isFullscreen)
    {
        Screen.fullScreen = isFullscreen;
    }

    private void Start()
    {
        resolutions = Screen.resolutions;
        resDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + " x " + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResolutionIndex = i;

            }
        }
        resDropdown.AddOptions(options);
        resDropdown.value = currentResolutionIndex;
        resDropdown.RefreshShownValue();

        LoadSettings();
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    #endregion
}
