using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallScore : MonoBehaviour
{
    public GameObject kickOff;
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
        Scored(); 
    }

    void Scored()
    {
        transform.position = kickOff.transform.position;
        ballRB.velocity = Vector2.zero;
        ballRB.angularVelocity = 0;
        Controller.score++;

    }
}
