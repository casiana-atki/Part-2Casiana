using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CutleryBehaviour : MonoBehaviour
{
    public float speed = 15f;
    Rigidbody2D cutleryRB;
    public Sprite[] cutleryModels;
    public float time = 0;
    public GameObject bread;

    void Start()
    {
        cutleryRB = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = cutleryModels[Random.Range(0, cutleryModels.Length)];
        Destroy(gameObject, 10);
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
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.gameObject.SendMessage("Hit", 1);
        }
    }
}
