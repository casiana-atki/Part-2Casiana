using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    public List<Vector2> points;
    public float newPointThreshold = 0.2f;
    Vector2 lastPosition;
    LineRenderer lineRenderer;
    Vector2 currentPosition;
    Rigidbody2D rigibody;
    public float speed = 1.0f;
    public AnimationCurve landing;
    float landingTimer;
    public GameObject otherPlane;
    float range; 
    SpriteRenderer sprtrender;
    public float collisionRange = 0.47f; 
    //When writing this array, it allows you to put in sprites for your prefab. With later code, these sprites can be randomized upon launch. 
    public Sprite[] planeModels; 

    private void Start()
    {
        sprtrender = GetComponent<SpriteRenderer>(); 
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1; 
        lineRenderer.SetPosition(0, transform.position);

        rigibody = GetComponent<Rigidbody2D>();
        GetComponent<SpriteRenderer>().sprite = planeModels[Random.Range(0, planeModels.Length)];
        speed = Random.Range(1.0f, 3.0f);
    }

    private void FixedUpdate()
    {
        currentPosition = transform.position;
        if(points.Count > 0 )
        {
            Vector2 direction = points[0] - currentPosition;
            float angle = Mathf.Atan2( direction.x, direction.y ) * Mathf.Rad2Deg;
            rigibody.rotation = -angle;
        }
        rigibody.MovePosition(rigibody.position + (Vector2)transform.up * speed * Time.deltaTime);
    }

    private void Update()
    {
         
        
        if (Input.GetKey(KeyCode.Space))
        { //Makes the landing timer get a little bigger each time, we go through the landing curve to get back the height of the curve 
            landingTimer += 0.1f * Time.deltaTime;
            float interpolation = landing.Evaluate(landingTimer);
            if(transform.localScale.z < 0.1)
            {
                Destroy(gameObject);
            }

            //here we get the value for how far we've travelled from our last value 
            transform.localScale = Vector3.Lerp(transform.localScale, Vector3.zero, interpolation);
        }

        lineRenderer.SetPosition(0, transform.position);  
        if (points.Count > 0 )
        {
            if(Vector2.Distance(currentPosition, points[0]) < newPointThreshold)
            {
                points.RemoveAt(0);

                for (int i = 0; i < lineRenderer.positionCount - 2; i++)
                    {
                    lineRenderer.SetPosition(i, lineRenderer.GetPosition(i + 1));

                }
                lineRenderer.positionCount--;
            }
        }
    }

    private void OnMouseDown()
    {
        points = new List<Vector2>();
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        points.Add(newPosition);
        lineRenderer.positionCount = 1;
        lineRenderer.SetPosition(0, newPosition);
    }

    private void OnMouseDrag()
    {
        Vector2 newPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        if (Vector2.Distance(lastPosition, newPosition) > newPointThreshold)
        {
            points.Add(newPosition);
            lineRenderer.positionCount++;
            lineRenderer.SetPosition(lineRenderer.positionCount - 1, newPosition);
            lastPosition = newPosition;
        }
    }

    private void OnBecameInvisible()
    {
        Destroy(gameObject);
    }

    private void OnTriggerEnter2D(Collider2D collision)
     {
        range = Vector3.Distance(currentPosition, collision.transform.position);  
         if (range > 0.40f)
         {
             if (otherPlane.activeInHierarchy)
             {
                 sprtrender.color = Color.red;
             }
         }
     }




    private void OnCollisionEnter2D(Collision2D collision)
    {
        range = Vector3.Distance(currentPosition, collision.transform.position);
        if (range > 0.16)
        {
            Destroy(gameObject);
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (otherPlane.activeInHierarchy)
        {
            sprtrender.color = Color.white;
        }
    }

}
