using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Health : MonoBehaviour
{
    public int hitPoint = 2;
    public int currencyWorth = 50;
    private bool isDestroyed = false;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    public void TakeDamage(int dmg){
        hitPoint -= dmg;
        StartCoroutine(DamageColor(0.5f, Color.red));
        if(hitPoint <= 0 && !isDestroyed){
            LevelManager.main.IncreseCurrency(currencyWorth);
            isDestroyed =true;
            Destroy(gameObject);
        }
    }


    IEnumerator DamageColor(float time, Color color)
    {
        spriteRenderer.color = color;
        yield return new WaitForSeconds(time);
        spriteRenderer.color = Color.white;
    }
}
