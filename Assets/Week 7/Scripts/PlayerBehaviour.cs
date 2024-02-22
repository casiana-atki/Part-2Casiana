using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerBehaviour : MonoBehaviour
{
    public Color selectedColor;
    public Color unselectedColor; 
    public SpriteRenderer playerSprite;
    Rigidbody2D rigi;
    public float speed = 100;


    void Start()
    {
        playerSprite = GetComponent<SpriteRenderer>();
        Selected(false);
        rigi = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnMouseDown()
    {
        Selected(true);
        Controller.SetCurrentSelection(this);
        
    }
    public void Selected(bool isSelected)
    {
        if (isSelected)
        {
            playerSprite.color = Color.green;  
        }
        else 
        {
            playerSprite.color = Color.red;  
        }
    }
    public void Move(Vector2 direction)
    {
        rigi.AddForce(direction * speed, ForceMode2D.Impulse); 
    }
}
