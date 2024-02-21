using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using TMPro;

public class Timer : MonoBehaviour
{
    public float maxTime = 60;
    public Slider slider;
/*    TextMeshProUGUI textMeshPro;
    string timer;
    int timeLeft;
    public GameObject timertext;*/
   
    void Start()
    {
       // textMeshPro = timertext.GetComponent<TextMeshProUGUI>();
    }

    public void Update()
    {
        maxTime -= 1 * Time.deltaTime;
        slider.value = maxTime;
      /*  timeLeft = (int)maxTime;
        timer = timeLeft.ToString();
        textMeshPro.text = timeLeft.ToString();*/
        

    }

}



