using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LostMenu : MonoBehaviour
{
    public GameObject LostMenuUi;

    void Start()
    {
        LostMenuUi.SetActive(false);
    }
    
    public void LostRestart()
    {
        string ScenName = SceneManager.GetActiveScene().name;
        SceneManager.LoadScene(ScenName);
    }

    public void LostBackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LostExtit()
    {
        Application.Quit();
    }

    public void LostMenuActiveate()
    {
        LostMenuUi.SetActive(true);
        Time.timeScale=0f;
    }


}
