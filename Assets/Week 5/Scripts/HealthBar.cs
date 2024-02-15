using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    
    public void Start()
    {
        slider.value = PlayerPrefs.GetFloat("Health", slider.value);
        SendMessage("HealthValue", slider.value, SendMessageOptions.DontRequireReceiver);   
    }
    public void TakeDamage(float damage)
    {
        slider.value -= damage;
        Health();
    }

    public void Health()
    {
        PlayerPrefs.SetFloat("Health", slider.value);
    }
}
