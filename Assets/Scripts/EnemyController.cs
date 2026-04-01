using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyController : MonoBehaviour

{
    public float speed;
    public bool vertical;
    public float changeTime = 3.0f;
    
    Rigidbody2D rigidbody2D;
    private float timer;
    private int direction = 1;
    
    // Start is called before the first frame update
    void Start()
    {
        rigidbody2D = GetComponent<Rigidbody2D>();
        timer = changeTime;
    }

    // Update is called once per frame
    private void Update()
    {
        timer -= Time.deltaTime;
        
        if (timer < 0)
        {
            direction = -direction;
            timer = changeTime;
        }
    }

    void FixedUpdate()
    {
        Vector2 position = rigidbody2D.position;
        if (vertical)
        {
            position.y = position.y + speed * direction * Time.deltaTime;
        }
        else
        {
            position.x = position.x + speed * direction * Time.deltaTime;
        }
        
        rigidbody2D.MovePosition(position);
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        PlayerController player = other.gameObject.GetComponent<PlayerController>();

        if (player != null)
        {
            player.ChangeHealth(-1);
        }
    }
}
