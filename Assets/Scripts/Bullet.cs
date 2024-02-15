using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEditor;
using UnityEngine.Rendering;

public class Bullet : MonoBehaviour
{
    public Rigidbody2D rb;
   private float bulletSpeed = 5f;
   private Transform target;
   public int bulletDamage ;
   public float rocketrange=2f;
    
   public float slow = 0.5f;

   public float slowtime = 4f;

   public bool upgradeamo =false;
   public void SetTarget(Transform _target){
    target = _target;

   }
   private void FixedUpdate(){
    if (!target){
        Destroy(gameObject);
        return;
    }
    
    Vector2 dir = target.position - transform.position;
    float distanceThisFrame = bulletSpeed * Time.deltaTime;
    transform. Translate(dir.normalized *distanceThisFrame, Space. World);
    StartCoroutine(FollowTarget());
   }
   
     IEnumerator FollowTarget()
    {
        while (target != null)
        {
        float dir =  Mathf.Atan2(target.position.y - transform.position.y, target.position.x- transform.position.x)*Mathf.Rad2Deg - 90f;
        Quaternion targetRotation = Quaternion.Euler(new Vector3(0f, 0f, dir));
        transform.rotation= targetRotation;
        yield return null;
        }
    }
    private void OnCollisionEnter2D(Collision2D other){

        if(gameObject.tag=="Slow"){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rocketrange);
        foreach (Collider2D collider in colliders)
        {
        if (collider.tag == "Enemy")
        {
            
            if(upgradeamo)
            {
                collider.gameObject.GetComponent<Enemy>().StartEfect(slow+0.1f, slowtime+1);
            }
            else
            {
                collider.gameObject.GetComponent<Enemy>().StartEfect(slow, slowtime);
            }
            Destroy(gameObject);
        }
        
        }
        }
        else if(gameObject.tag=="Explo"){
        Collider2D[] colliders = Physics2D.OverlapCircleAll(transform.position, rocketrange);
        foreach (Collider2D collider in colliders)
        {
        if (collider.tag == "Enemy")
        {
            if(upgradeamo)
            {
                collider.gameObject.GetComponent<Health>().TakeDamage(bulletDamage+10);
            }
            else
            {
                collider.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            }
        
        Destroy(gameObject);}
        } 
        }else if(gameObject.tag=="Turret")
        {
            if(upgradeamo)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage+10);
                
            }
            else
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            }
        Destroy(gameObject);
        }else if(gameObject.tag=="double")
        {
            if(upgradeamo)
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage+10);
            }
            else
            {
                other.gameObject.GetComponent<Health>().TakeDamage(bulletDamage);
            }
        Destroy(gameObject);
        upgradeamo=false;
    }

   }
    public void SetTurretUpgrade(bool up)
    {   
        upgradeamo=up;
    }
   public void UpgrdeDamage(int dmg)
   {
        bulletDamage+=dmg;
   }
   public void UpgradeSlow(float sl,int st)
   {
        slow+=sl;
        slowtime+=st;

   }
   public void UpgradeRange(float range){
    rocketrange+=range;
   }
   /*void OnDrawGizmosSelected ()
	{
		Handles.color = Color.red;
		Handles.DrawWireDisc(transform.position,transform.forward, rocketrange);
	}*/
}

    
