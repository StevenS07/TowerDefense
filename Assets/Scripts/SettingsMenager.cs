using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class SettingsMenager : MonoBehaviour
{   
    public Toggle fullscreenTog;

    public List<ResolutionItems> resolutions = new List<ResolutionItems>();

    private int selectedresolution;

    public TMP_Text resolutionlabel;
     public void BackMenu()
    {
        SceneManager.LoadScene("Menu");
    }

    public void Start()
    {
        fullscreenTog.isOn = Screen.fullScreen;

        
    }
    public void ResLeft()
    {
        selectedresolution--;
        if(selectedresolution<0)
        {
            selectedresolution=0;
        }
        UpdateResolutionLabel();
    }
    public void ResRight()
    {
        selectedresolution++;
        if(selectedresolution> resolutions.Count -1)
        {
            selectedresolution=resolutions.Count -1;
        }

        UpdateResolutionLabel();
    }

    public void UpdateResolutionLabel()
    {
        resolutionlabel.text= resolutions[selectedresolution].horizontal.ToString()+ " x "+resolutions[selectedresolution].vertical.ToString();
    }
    public void ApllyGraphicsSettings()
    {
        

        Screen.SetResolution(resolutions[selectedresolution].horizontal,resolutions[selectedresolution].vertical, fullscreenTog.isOn);
    }
    
    
}
[System.Serializable]
public class ResolutionItems
    {
        public int horizontal, vertical;
    }