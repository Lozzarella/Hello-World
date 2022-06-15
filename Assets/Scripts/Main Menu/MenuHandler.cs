using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MenuHandler : MonoBehaviour
{
    public Transform playerTrans;
    public void ChangeScene(int sceneIndex)
    {
        SceneManager.LoadScene(sceneIndex);
    }

    public void LoadSlotOne()
    {
        StartBobsWorld.loadPath = SaveData.path1;
    }
    public void LoadSlotTwo()
    {
        StartBobsWorld.loadPath = SaveData.path2;
    }
    public void OnApplicationQuit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#endif
        Application.Quit();
    }

    
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
        }
        else
        {
            masterAudio.SetFloat(currentSlider, tempSlider.value);
            tempSlider.interactable = true;
        }
    }

    public void CurrentSlider(string sliderName)
    {
        currentSlider = sliderName;
    }
    
    public void ChangeVolume (float volume)
    {
        masterAudio.SetFloat(currentSlider, volume);
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
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution res = resolutions[resolutionIndex];
        Screen.SetResolution(res.width, res.height, Screen.fullScreen);
    }

    #endregion
}
