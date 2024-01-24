using UnityEngine;
using UnityEngine.SceneManagement;

public class GameOver : MonoBehaviour
{
    public void Retry(){
        SceneManager.LoadScene("level1");
    }
    public void MainMenu(){
        SceneManager.LoadScene("MainMenu");
    }


}
