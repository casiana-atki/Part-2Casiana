using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    Rigidbody2D rigi;
    public SpriteRenderer playerSprite;
    bool clickedOnSelf = false; 

    void Start()
    {
        rigi = GetComponent<Rigidbody2D>();
        playerSprite = GetComponent<SpriteRenderer>();  
    }

    void Update()
    {
        Selected(); 
    }

    private void OnMouseDown()
    {
        clickedOnSelf = true;
    }

    private void OnMouseUp()
    {
        clickedOnSelf = false;
    }

    void Selected()
    {
        if (clickedOnSelf == true)
        {
            playerSprite.color = Color.green; 
        }
        else if (clickedOnSelf == false)
        {
            return; 
        }
    }
}
