using System.Collections;
using System.Collections.Generic;
using System.ComponentModel.Design.Serialization;
using UnityEngine;

public class Plot : MonoBehaviour
{
    public SpriteRenderer sr;
    public Color hoverColor;
    private GameObject tower;
    private Color startColor;

    private void Start(){
        startColor = sr.color;
    }

    
    private void OnMouseEnter()
    {
        sr.color =startColor;
    }
    private void OnMouseExit(){
        sr.color = startColor;
        
    }

    private void OnMouseDown(){
        
        Tower towerToBuild = BuildMenager.main.GetSelectedTower();
         if(tower != null || towerToBuild.name=="Sell" || towerToBuild.name=="Upgrade")
        {
            return;
        }else 
        {  
            if(towerToBuild.cost > LevelManager.main.currency)
            {
                Debug.Log("u cant buy");
                return;
            }else
            {
                LevelManager.main.SpendCurrency(towerToBuild.cost);
                tower = Instantiate(towerToBuild.prefab, transform.position, Quaternion.identity);
                Turret turretinfo = FindAnyObjectByType<Turret>();
                turretinfo.SellUi.enabled=false;
                turretinfo.UpgradeUi.enabled=false;
            }
            
            
        }
    }
        

}
