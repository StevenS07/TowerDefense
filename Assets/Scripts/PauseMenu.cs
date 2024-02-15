using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PauseMenu : MonoBehaviour
{
    public GameObject PauseMenuUi;
    public static bool GamePause = false;
    void Update()
    {
        if(Input.GetKeyDown(KeyCode.Escape))
        {
            if(GamePause)
            {
                PauseOff();
            }
            else
            {
                PauseOn();
            }
            
        }
    }

    public void PauseOff(){
        PauseMenuUi.SetActive(false);
        Time.timeScale=1f;
        GamePause=false;
    }

    public void PauseOn(){
        PauseMenuUi.SetActive(true);
        Time.timeScale=0f;
        GamePause=true;
    }

    public void Restart()
    {
      Time.timeScale=1f;
      string ScenName = SceneManager.GetActiveScene().name;
      SceneManager.LoadScene(ScenName);
    }

    public void BackMenu()
    {
        Time.timeScale=1f;
        SceneManager.LoadScene("Menu");
    }
    public void ExitGame()
    {
        Application.Quit();
    }
    
}
