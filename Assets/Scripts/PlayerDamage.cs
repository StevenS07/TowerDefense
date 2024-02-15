using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerDamage : MonoBehaviour
{
    
    public HealthBar healthBar;
    
    public void OnCollisionEnter2D(Collision2D other)
    {
          
            Enemy enemyComponent = other.gameObject.GetComponent<Enemy>();

        if (enemyComponent != null)
        {
            
            LevelManager.main.TakeDamage(enemyComponent.dmg);
            
        }
    
    }
    
}
