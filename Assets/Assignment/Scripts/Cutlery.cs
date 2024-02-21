using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutleryBehaviour : MonoBehaviour
{
    public float speed = 10f;
    Rigidbody2D cutleryRB;
    public GameObject cutleryPREFAB; 
    public Sprite[] cutleryModels;
    public float time = 0; 

    void Start()
    {
        cutleryRB = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = cutleryModels[Random.Range(0, cutleryModels.Length)];
        Destroy(gameObject, 15);
    }

    void Update()
    {
        time += 1 * Time.deltaTime; 
    }

    private void FixedUpdate()
    {
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        cutleryRB.MovePosition(cutleryRB.position - direction);

  
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("Hit", 1);
        Destroy(gameObject);

    }
}
