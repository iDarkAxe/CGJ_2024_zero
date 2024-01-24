using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PausePanel;
    public GameObject settingsPanel;
    public static bool gameIsPaused = false;
    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if (gameIsPaused)
            {
                Resume();
            }
            else
            {
                Paused();
            } 
        }
    }
    private void Paused(){
        PlayerMovement.instance.enabled = false;
        PausePanel.SetActive(true);
        Time.timeScale = 0;
        gameIsPaused = true;
    }

    public void Resume(){
        PlayerMovement.instance.enabled = true;
        PausePanel.SetActive(false);
        Time.timeScale = 1;
        gameIsPaused = false;
    }
    public void MainMenu(){
        Time.timeScale = 1;
        SceneManager.LoadScene("MainMenu");        
    }
    public void SettingsButton(){
        settingsPanel.SetActive(true);
    }
    public void CloseSettingsMenu(){
        settingsPanel.SetActive(false);
    }
}
