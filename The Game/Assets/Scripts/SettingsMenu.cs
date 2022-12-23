using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using TMPro;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixer audioMixer;
    public Slider musicSlider;
    public Slider gameSlider;
    public static SettingsMenu Instance;

    //for resolution
    public Dropdown resolutionDropdown;
    Resolution[] resolutions; //resolution array

     void Start()
    {
        resolutions = Screen.resolutions;

        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();

        int currentResIndex = 0;

        for(int i = 0; i < resolutions.Length;i++) 
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);

            if (resolutions[i].width == Screen.currentResolution.width && resolutions[i].height == Screen.currentResolution.height)
            {
                currentResIndex = i;
            }
        }

        resolutionDropdown.AddOptions(options); 
        resolutionDropdown.value= currentResIndex;
        resolutionDropdown.RefreshShownValue();
    }
    private void Awake()
    {
        if (Instance == null)
        {
            Instance = this;
            DontDestroyOnLoad(gameObject);
        }
        else if (Instance != this)
        {
            Destroy(gameObject);
        }
        GetVolume();
    }

    public void GetVolume()
    {
        float music = AudioManager.Instance.music;
        float game = AudioManager.Instance.game;

        musicSlider.value = music;
        gameSlider.value = game;
    }
    public void SetMusicVolume(float music)
    {

        audioMixer.SetFloat("music", music);

    }
    public void SetGameVolume(float game)
    {
        audioMixer.SetFloat("game", game);

    }
    public void SetFullScreen(bool isFullScreen) 
    {
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex)
    {
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
