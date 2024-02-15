
using UnityEngine;

public class LevelManager : MonoBehaviour
{   
    
    public static LevelManager main;
    public int currency;
    public HealthBar healthBar;
    public int maxHealth = 100;
    public int currentHealth;
    public LostMenu lostmenu;
    public Camera mainCamera;
    public float camerasize;
    private void Awake(){
        mainCamera.orthographicSize=camerasize;
        main = this;
       
    }

    
    private void Start(){
        currentHealth = maxHealth;
        Debug.Log(maxHealth);
        healthBar.SetMaxHealth(maxHealth);
    
    }

    public void IncreseCurrency(int amount){
        currency += amount;
    }

    public void SellTurret (int amount)
    {
        currency+=amount;
    }
    public bool SpendCurrency(int amount){
        if(amount <= currency){
            currency -= amount;
            return true;
        }else{
            Debug.Log("u dont have money ");
            return false;
        }
    }

    public void TakeDamage(int damage)
    {
        currentHealth-= damage;
        healthBar.SetHealth(currentHealth);
        if(currentHealth<=0)
        {
            lostmenu.LostMenuActiveate();
        }

        
    }
    
}
