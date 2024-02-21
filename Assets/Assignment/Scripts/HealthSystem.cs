using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthSystem : MonoBehaviour
{

    public Slider slider;

    public void Start()
    {
        slider.value = 5; 
    }
    public void Hit(float damage)
    {
        slider.value -= damage;

    }

}
