using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
   public GameObject Player;
   private Transform target; 
   private float speed = 0.1f;
   private Vector2 dir;
   private Rigidbody2D rb;

    void Start()
    {
        speed = 1f;
        rb = GetComponent<Rigidbody2D>();
        Movement();
        target = Player.transform;
    }

    // Update is called once per frame
    void Update()
    {
        transform.position = Vector3.MoveTowards(transform.position, target.position, speed); 
    }

    void Movement() 
    {
        do
        {
            dir.x = Random.Range(-1, 2);
        }
        while (dir.x == 0);
        
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<DeathZone>())
        {
            Destroy(gameObject);
        }

        if (collision.GetComponent<MarioMovement>())
        {
            Destroy(gameObject);
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<TilemapCollider2D>()) 
        { 
        
        }
    }
}
