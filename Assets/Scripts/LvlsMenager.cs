using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LvlsMenager : MonoBehaviour
{
    public void Back()
    {
        SceneManager.LoadScene("Menu");
    }

    public void LoadLvl(int lvlnumb)
    {
        SceneManager.LoadScene(lvlnumb);
    }
}
