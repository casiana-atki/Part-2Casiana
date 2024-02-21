using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Movement : MonoBehaviour
{
    Rigidbody2D rb;
    Vector2 destination;
    Vector2 movement;
    public float speeed = 3;
    Animator animator;
    bool clickedOnSelf = false;
    bool isDead = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        destination = transform.position;
 
    }

    private void FixedUpdate()
    {
        if (isDead) return;
        movement = destination - (Vector2)transform.position;

        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero;
        }
        rb.MovePosition(rb.position + movement.normalized * speeed * Time.deltaTime);
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0) && !clickedOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }



    }

}
    
