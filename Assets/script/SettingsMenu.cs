using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Audio;
using UnityEngine.UI;
using System.Linq;

public class SettingsMenu : MonoBehaviour
{
    public AudioMixerGroup audioMixerGroup;
    public Resolution[] resolutions;
    public Dropdown resolutionDropdown;
    public Toggle checkBoxFullScreen;
    public Toggle checkBoxMuteVolume;
    public Slider sliderMasterVolume;
    List<DisplayInfo> displayLayout;

    private void Start() {
        resolutions = Screen.resolutions
    .Where(resolution => resolution.width >= 1280 && resolution.height >= 720)
    .Select(resolution => new Resolution { width = resolution.width, height = resolution.height })
    .Distinct()
    .ToArray();
        resolutionDropdown.ClearOptions();
        List<string> options = new List<string>();
        int currentResolutionIndex = 0;
        for (int i = 0; i < resolutions.Length; i++)
        {
            string option = resolutions[i].width + "x" + resolutions[i].height;
            options.Add(option);
            if (resolutions[i].width == Screen.width && resolutions[i].height == Screen.height)
            {
                currentResolutionIndex = i;
            }
        }
        resolutionDropdown.AddOptions(options);
        resolutionDropdown.value = currentResolutionIndex;
        resolutionDropdown.RefreshShownValue();
        bool isFullScreen = Screen.fullScreen;
        checkBoxFullScreen.isOn = isFullScreen;
    }
    public void SetMuteVolume(bool isMute){
        if(isMute){
            audioMixerGroup.audioMixer.SetFloat("Master", -80);
        }
        else{
            SetMasterVolume(sliderMasterVolume.value);
        }
    }

    public void SetMasterVolume(float volume){
        if (!checkBoxMuteVolume.isOn)
        {
            audioMixerGroup.audioMixer.SetFloat("Master", volume);
        }
    }
    public void SetMusicVolume(float volume){
        audioMixerGroup.audioMixer.SetFloat("Music", volume);
    }
    public void SetSoundEffectVolume(float volume){
        audioMixerGroup.audioMixer.SetFloat("SoundEffect", volume);
    }

    public void setFullScreen(bool isFullScreen){
        Screen.fullScreen = isFullScreen;
    }

    public void SetResolution(int resolutionIndex){
        Resolution resolution = resolutions[resolutionIndex];
        Screen.SetResolution(resolution.width, resolution.height, Screen.fullScreen);
    }

}
