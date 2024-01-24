using UnityEngine;
using System;
using UnityEngine.SceneManagement;

public class MainMenu : MonoBehaviour
{
    public String levelToLoad;
    public GameObject settingsPanel;
    public AudioSource audioSource;
    public AudioClip clip;

    public void Start(){
        audioSource.clip = clip;
        audioSource.loop = true;
        audioSource.Play();
    }
    

    public void StartGame(){
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsButton(){
        settingsPanel.SetActive(true);
    }
    public void LoadCredits(){
        SceneManager.LoadScene("Credits");
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void CloseSettingsMenu(){
        settingsPanel.SetActive(false);
    }
}
