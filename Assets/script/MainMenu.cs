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
        audioSource.Play();
    }
    private void Update() {
        if (!audioSource.isPlaying)
        {
            audioSource.Play();
        }
    }

    public void StartGame(){
        SceneManager.LoadScene(levelToLoad);
    }
    public void SettingsButton(){
        settingsPanel.SetActive(true);
    }
    public void QuitGame(){
        Application.Quit();
    }
    public void CloseSettingsMenu(){
        settingsPanel.SetActive(false);
    }
}
