using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEditor;
using UnityEngine.UIElements;
using TMPro;
using System.ComponentModel.Design.Serialization;
using System;
using UnityEngine.EventSystems;

public class Turret : MonoBehaviour
{   
    public int cost=0;
    private Transform target;
    public Animator anim;
    public float range=15f;
    public Transform partToRotate;
    public string enemyTag = "Enemy";
    public float turnSpeed = 10f;
    public GameObject bulletPrefab;
    public Transform firePoint1;
    public Transform firePoint2;
    public float bps = 1f;
    private float timeUnitFire;
    public Canvas UpgradeUi;
    public Canvas SellUi;
    public TextMeshProUGUI upgradetext;
    public TextMeshProUGUI selltext;
    public bool upgrade=false;
    public int upgradecost=10;
    public int sellcost=10;
     public int dmg;
    void Start()
    {   
        UpgradeUi.enabled =false;
        SellUi.enabled =false;
        InvokeRepeating("UpdateTarget",0f,0.5f);
    }
    private void OnGUI(){
        upgradetext.text=upgradecost.ToString();
        selltext.text=sellcost.ToString();
        
        }
    void UpdateTarget()
    {   
        
        anim.SetBool("Shot", false);
        GameObject[] enemies = GameObject.FindGameObjectsWithTag(enemyTag);
        float shortestDistance = Mathf.Infinity;
        GameObject nerestEnemy = null;
        foreach(GameObject enemy in enemies)
        {
            float disranceToEnemy = Vector3.Distance(transform.position, enemy.transform.position);
            if(disranceToEnemy < shortestDistance)
            {
                shortestDistance = disranceToEnemy;
                nerestEnemy = enemy;
            }
        }

        if (nerestEnemy != null && shortestDistance <= range)
        {
             target = nerestEnemy.transform;
         
        }else
        {
            target = null;
        }
    }
    // Update is called once per frame
    void Update()
    {   
        
        if(target == null)
            return;

        float dir =  Mathf.Atan2(target.position.y - transform.position.y, target.position.x- transform.position.x)*Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, dir));
        partToRotate.rotation= targetRotation;
        timeUnitFire += Time.deltaTime;
        if(timeUnitFire >= 1f/bps){
            Shoot();
            timeUnitFire =0f;             
        }
        
    }
    public void UpgradeTurret(string type)
    {
        if(type == "Turret" && upgrade == false && cost*2 <= LevelManager.main.currency)
        {
            
            range+=0.5f;
            bps+=0.5f;
            LevelManager.main.SpendCurrency(upgradecost);
            upgrade = true;
        }else if(type == "double" && upgrade == false && cost*2 <= LevelManager.main.currency)
        {   
            ;
            range+=1f;
            bps+=1f;
            LevelManager.main.SpendCurrency(upgradecost);
            upgrade = true;
        }else if(type == "Slow" && upgrade == false && cost*2 <= LevelManager.main.currency)
        {   
            Bullet bulletupgrade = bulletPrefab.GetComponent<Bullet>();
            bulletupgrade.UpgradeRange(2);
            range+=1f;
            bps+=0.15f;
            LevelManager.main.SpendCurrency(upgradecost);
            upgrade = true;
        }else if(type == "Explo" && upgrade == false && cost*2 <= LevelManager.main.currency)
        {  
            Bullet bulletupgrade = bulletPrefab.GetComponent<Bullet>();
            bulletupgrade.UpgradeRange(1);
            range+=1f;
            bps+=0.2f;
            LevelManager.main.SpendCurrency(upgradecost);
            upgrade = true;
        }

    }
    private void animations(){
        anim.SetBool("Shot", true);
    }
   
    private void Shoot(){
        
        if(gameObject.tag == "double"){
        GameObject bulletObject1 = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
        GameObject bulletObject2 = Instantiate(bulletPrefab, firePoint2.position, Quaternion.identity);
        Bullet bulletScript = bulletObject1.GetComponent<Bullet>();
        Bullet bulletScript2 = bulletObject2.GetComponent<Bullet>();
        animations();
        bulletScript.SetTarget(target);
        bulletScript2.SetTarget(target);
        bulletScript.SetTurretUpgrade(upgrade);
        bulletScript2.SetTurretUpgrade(upgrade);
        
        
        }else
        {
        GameObject bulletObject = Instantiate(bulletPrefab, firePoint1.position, Quaternion.identity);
        Bullet bulletScript1 = bulletObject.GetComponent<Bullet>();
        animations();
        bulletScript1.SetTarget(target);
        bulletScript1.SetTurretUpgrade(upgrade);
        
        }
        
        
    }
    public void OnMouseEnter(){
        
        Tower towerToBuild = BuildMenager.main.GetSelectedTower();
        if(towerToBuild.name == "Sell"){
            SellUi.enabled = true;
        }
         else if(towerToBuild.name == "Upgrade"){
            Turret turretinfo = GetComponent<Turret>();
            turretinfo.UpgradeUi.enabled=true;
         }
    }

    public void OnMouseExit(){
        Tower towerToBuild = BuildMenager.main.GetSelectedTower();
        if(towerToBuild.name == "Sell"){
            SellUi.enabled = false;
        }
         else if(towerToBuild.name == "Upgrade"){
            Turret turretinfo = GetComponent<Turret>();
            turretinfo.UpgradeUi.enabled=false;
         }
    }

    public void OnMouseDown(){
        Tower towerToBuild = BuildMenager.main.GetSelectedTower();
        if(towerToBuild.name == "Sell"){
            LevelManager.main.SellTurret(sellcost);
            Destroy(gameObject);
        }
         else if(towerToBuild.name == "Upgrade"){
            UpgradeTurret(gameObject.tag);
         }
    }


   /* void OnDrawGizmosSelected ()
	{
		Handles.color = Color.red;
		Handles.DrawWireDisc(transform.position,transform.forward, range);
	}*/
}

