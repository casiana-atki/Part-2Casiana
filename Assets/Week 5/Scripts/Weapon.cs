using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Weapon : MonoBehaviour
{
    public float speed = 10;
    Rigidbody2D rigibody;
    public float deleteTime = 10; 

    void Start()
    {
        rigibody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        //The timer so that the mace will delete after 20 seconds, I also made it so when the item deletes, the timer resets for when the item will be spawned as a prefab. 
        //The item might go off screen but you should still be able to see that it does delete. 
        deleteTime += 1 * Time.deltaTime;
        if (deleteTime > 20)
        {
            Destroy(gameObject);
            deleteTime = 0; 
        }
        Vector2 direction = new Vector2(speed * Time.deltaTime, 0);
        rigibody.MovePosition(rigibody.position - direction);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        collision.gameObject.SendMessage("TakeDamage", 1);
        Destroy(gameObject);

    }

}
