using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreUI : MonoBehaviour
{
    public static TextMeshProUGUI showScore; 
    void Start()
    {
        showScore = gameObject.GetComponent<TextMeshProUGUI>();
    }


    void Update()
    {
        
    }
}
