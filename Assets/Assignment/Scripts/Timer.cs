using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UIElements;
using Slider = UnityEngine.UI.Slider;
using TMPro;
using UnityEngine.SceneManagement;

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

        if (maxTime <= 0) SceneManager.LoadScene("GameOver");

    }

}



