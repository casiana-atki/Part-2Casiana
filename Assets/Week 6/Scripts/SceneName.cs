using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;

public class SceneName : MonoBehaviour
{
    //Text in the scene will be TextMeshPro but text in a canvas (UI) uses TextMeshProUGUI
    TextMeshProUGUI sceneName; 
    void Start()
    {
        //grabs the component for us to use in our code
        sceneName = GetComponent<TextMeshProUGUI>();
        //assigns value displayed on screen to the name of the active scene
        sceneName.text = SceneManager.GetActiveScene().name; 
    }
}
