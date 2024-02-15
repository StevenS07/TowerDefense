
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class MenuMenager : MonoBehaviour
{
 
   
    public void Lvls()
    {
        SceneManager.LoadScene("LvlMenu");
    }

    public void Settings()
    {
        SceneManager.LoadScene("Settings");
    }

    public void Exit()
    {
        Application.Quit();
    }

}
