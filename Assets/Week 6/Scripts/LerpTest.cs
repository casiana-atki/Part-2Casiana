using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LerpTest : MonoBehaviour
{
    public AnimationCurve animationcurve; 
    public Transform startPos;
    public Transform endPos;
    public float lerpTimer;
    public float interpolation;
    public Color colora;
    public Color colorb; 
    public SpriteRenderer spriterenderer;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        interpolation = animationcurve.Evaluate(lerpTimer);
        //Make sure that startPos and endPos become Vector3s by adding .position after 
        transform.position = Vector3.Lerp(startPos.position, endPos.position, interpolation);

        lerpTimer = lerpTimer + Time.deltaTime;
        //you can also lerp through colours (make something change between two colours) 

        //The sprite renderer uses these different colors so color a transitions to color b via interpolation 
        spriterenderer.color = Color.Lerp(colora, colorb, interpolation);
    }
}
