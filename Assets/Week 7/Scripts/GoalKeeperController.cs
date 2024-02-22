using UnityEngine.UI;
using UnityEngine.EventSystems;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GoalKeeperController : MonoBehaviour
{
    Rigidbody2D gLrigi;
    public GameObject gL;
    Vector2 direction;
    public float maximumDistance = 3;
    public float gLSpeed = 3;
    Vector3 playerPosition;

    void Start()
    {
        gLrigi = GetComponent<Rigidbody2D>();

    }

    void Update()
    {
        playerPosition = Controller.CurrentSelection.transform.position;
        direction = (playerPosition - transform.position).normalized;

        if (Vector3.Distance(playerPosition, transform.position) < maximumDistance * 2)
        {
            gL.transform.position = Vector3.MoveTowards(gL.transform.position, (transform.position + (Vector3)(Vector3.Distance(playerPosition, transform.position) / 2 * direction)), gLSpeed * Time.deltaTime);
        }
        else
        {
            gL.transform.position = Vector3.MoveTowards(gL.transform.position, (transform.position + (Vector3)(maximumDistance * direction)), gLSpeed * Time.deltaTime);
        }
    }
}
