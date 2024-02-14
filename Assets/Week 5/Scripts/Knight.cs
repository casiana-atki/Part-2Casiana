using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using UnityEditor;
using UnityEngine;
using UnityEngine.EventSystems;

public class Knight : MonoBehaviour
{
    //call a reference to the rigidbody2d
    Rigidbody2D rb;
    //The destination is where we want the player to go
    Vector2 destination;
    //The movement is how the player will get there
    Vector2 movement;
    public float speeed = 3;
    //reference to animator
    Animator animator;
    //Making a boolean to check if we clicked on our player 
    bool clickedOnSelf = false;
    public float health;
    public float maxHealth = 5;
    //Making a boolean to check if we are dead, so that if we are dead, we can't move 
    bool isDead = false; 


    void Start()
    {
        //Calling the reference
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = maxHealth; 
    }

    //FixedUpdate happens before update (for physics)
    private void FixedUpdate()
    {
        if (isDead) return;
        //Destination is a vector 2 while transform.pos is a vector 3, so we make transform.pos a vector 2 by stating it 
        //This code says that the movement (way to get there) will be the aimed destination minus the current location
        movement = destination - (Vector2)transform.position;

        //If the movement is going to be less than 0.1 then don't move 
        if (movement.magnitude < 0.1)
        {
            movement = Vector2.zero; //I tried to do movement = 0; but this doesn't work because movement is a Vector2 so you need to use Vector2.zero, not a float or int  
        }

        //Unsure about this one, the rigidbody moves based off of these points? 
        //movement.normalized makes it so the movement won't exceed the speed? normalized makes the number smaller 
        rb.MovePosition(rb.position + movement.normalized * speeed * Time.deltaTime);



    }

    void Update()
    {   if (isDead) return;
        // 0 is the left click, here I'm saying "If the left mouse button is clicked" "!clickedOnSelf" means that we don't move when we click on ourselves
        //"!EventSystem.current.IsPointerOverGameObject()" essentially says that the code inside the if statement will only happen if you're not clicked on something in event system
        if (Input.GetMouseButtonDown(0) && !clickedOnSelf && !EventSystem.current.IsPointerOverGameObject())
        {
            //the destination is determined to be wherever the player clicked
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition); 
        }
        //References the float in the animator called "Movement" and makes it so that the movement is equaled to the movement.magnitude
        animator.SetFloat("Movement", movement.magnitude);

        if (Input.GetMouseButtonDown(1))
        {
            animator.SetTrigger("Attack");
        }
    }

    private void OnMouseDown()
    {   if (isDead) return; 
        clickedOnSelf = true;
        //replaces take damage and the need for the health bar 
        SendMessage("TakeDamage", 1); 

    }

    private void OnMouseUp()
    {
        clickedOnSelf = false;
    }

    public void TakeDamage(float damage)
    {
        health -= damage;
        //Mathf.Clamp makes it so that health is retrained because 2 numbers, if not, stuff happens 
        health = Mathf.Clamp(health, 0, maxHealth);
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death"); 
        }
        else
        {
            isDead = false; 
            animator.SetTrigger("Take Damage");
        }
    }
}
