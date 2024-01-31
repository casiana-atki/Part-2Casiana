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

    private void Start()
    {
        
        lineRenderer = GetComponent<LineRenderer>();
        lineRenderer.positionCount = 1; 
        lineRenderer.SetPosition(0, transform.position);

        rigibody = GetComponent<Rigidbody2D>();
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

}
