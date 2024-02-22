using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.SceneManagement;
using Unity.VisualScripting;

public class BreadBehaviour : MonoBehaviour
{
    Rigidbody2D rb;
    public float health;
    public float maxHealth = 5;
    Animator animator;
    bool isDead = false;
    Vector2 destination;
    Vector2 movement;
    public float speeed = 3;
    bool clickedOnSelf = false;
    public float points = 0;
    public TextMeshProUGUI score;
    SpriteRenderer spriteRenderer;
    public Color mold;
    float deathTimer;
    float colorTimer;
    public AnimationCurve colorSwitch;




    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
        health = PlayerPrefs.GetFloat("Health", maxHealth);
        destination = transform.position;
        health = maxHealth; 
        CurrentState();
        spriteRenderer = GetComponent<SpriteRenderer>();
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
    {   if (isDead) return;
        if (Input.GetMouseButtonDown(0) && !clickedOnSelf)
        {
            destination = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }

        if (points >= 5) WinScreen();
            

        if (health <= 0) GameOver();


        if (health <= 1)
        {
            colorTimer += 0.1f * Time.deltaTime;
            float interpolation = colorSwitch.Evaluate(colorTimer);
            spriteRenderer.color = Color.Lerp(spriteRenderer.color, mold, interpolation);
        }
        animator.SetFloat("Movement", movement.magnitude);
    }


    public void Hit(float damage)
    {   if(isDead) return;
        health -= damage;
        health = Mathf.Clamp(health, 0, maxHealth);
        CurrentState();
    }


    public void CurrentHealth(float value)
    {
        health = value;
    }


    public void CurrentState()
    {
        if (health <= 0)
        {
            isDead = true;
            animator.SetTrigger("Loss");
        }
        else
        {
            isDead = false;
            animator.SetTrigger("Hit");
        }
    }


    private void OnTriggerEnter2D(Collider2D collision)
    {
        if ( collision.CompareTag("Butter"))
        {
            AddPoint();
            Destroy(collision.gameObject);
        }
    }


    public void AddPoint()
    {
        points ++;
    }


    public void WinScreen()
    {
        SceneManager.LoadScene("GameWin");
    }


    public void GameOver()
    {

        SceneManager.LoadScene("GameOver");

    }

}
