using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;

public class Timer : MonoBehaviour
{
    public float time = 0;
    public float maxTime = 60;
    public Slider slider; 

    void Start()
    {
        slider.value = PlayerPrefs.GetFloat("CurrentTime", slider.value);
    }

    public void Update()
    {
        slider.value -= 1 * Time.deltaTime;
        CurrentTime();

    }

    public void CurrentTime()
    {
        PlayerPrefs.SetFloat("CurrentTime", slider.value);
    }
}



 */