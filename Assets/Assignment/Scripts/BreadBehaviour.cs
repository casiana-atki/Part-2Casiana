using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BreadBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public float health;
    public float maxHealth = 5;
    Animator animator;
    bool isDead = false;


    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
;
        //health = PlayerPrefs.GetFloat("Health", maxHealth);
        health = maxHealth;
        //CurrentState();
    }

    void Update()
    {
        
    }

    public void Hit(float damage)
    {
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        //CurrentState();

    }

   // public void HealthValue(float value)
   // {
        //health = value;
   // }

    /*public void CurrentState()
    {
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Death");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("Hit");
        }
    }*/
}
