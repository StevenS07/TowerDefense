using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class WinMenu : MonoBehaviour
{
    public GameObject WinMenuUi;

    void Start()
    {
        WinMenuUi.SetActive(false);
    }
    
    public void WinSelectLvl()
    {
        SceneManager.LoadScene("LvlMenu");
        
    }

    public void WinBackMenu()
    {
        SceneManager.LoadScene("Menu");
        
    }

    public void WinExtit()
    {
        Application.Quit();
    }

    public void WinMenuActiveate()
    {
        WinMenuUi.SetActive(true);
        Time.timeScale=0f;
    }


}
