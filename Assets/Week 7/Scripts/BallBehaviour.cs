using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallBehaviour : MonoBehaviour
{
    public GameObject kickOff;
    public int score;
    Rigidbody2D ballRB; 


    void Start()
    {
        ballRB = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        
    }

    void Scored()
    {
        score += 1;
        transform.position = kickOff.transform.position;
        ballRB.velocity = Vector2.zero; 

    }
    //Controller.scoreset = score; 
    //scoreset += 1
}
