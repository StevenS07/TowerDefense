using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuildMenager : MonoBehaviour
{
    public static BuildMenager main;
    public Tower[] towers;
    private int selectedTower=0;

    public bool sell = false;
    private void Awake(){
        main =this;

    }

    public Tower  GetSelectedTower(){
        return towers[selectedTower];
    }

    public void SetSelectedTower(int _selectedTower){
        selectedTower = _selectedTower;
    }

    public bool SellTower()
    {
        return sell=true;
    }


}
