using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;


public class Timer : MonoBehaviour
{
    public float maxTime = 60;
    public Slider slider;
   
    void Start()
    {

    }

    public void Update()
    {
        maxTime -= 1 * Time.deltaTime;
        slider.value = maxTime;


    }

}



