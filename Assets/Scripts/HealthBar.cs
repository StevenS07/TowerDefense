using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    
    
   public Slider slider;
  
   
   public void SetMaxHealth(int healht){

    slider.maxValue = healht;
    slider.value = healht;
    
   }
   public void SetHealth(int healht)
   {
    slider.value = healht;
   }

    
}
