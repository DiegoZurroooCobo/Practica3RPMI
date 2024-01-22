using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
   public GameObject Player;
   public float speed;
   private Vector2 dir;
   private Rigidbody2D rb;
   private float distance;
   private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Movement();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position); // Mide la distancia entre el enemigo y el personaje 
        Vector2 dir = Player.transform.position - transform.position; 

        if(distance < 3.5) //Si la distancia es menor que 3.5, el enemigo se movera en la direccion del jugador
        { 
        transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), speed * Time.deltaTime);      
        }

        //if(dir.x > 0.1) 
        //{ 
        //    spriteRenderer.flipX = true;
        //}
        //else if(dir.x < -0.1) 
        //{ 
        //    spriteRenderer.flipX = false;
        //}
    }

    void Movement() 
    {
        do{
            dir.x = Random.Range(-1, 2);
        }while (dir.x == 0);
                  
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.GetComponent<MarioMovement>()) 
        {
            Destroy(gameObject);
        } 
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.GetComponent<TilemapCollider2D>()) 
        //{
        //    dir.x = -dir.x;
        //}
        dir.x = -dir.x;
        spriteRenderer.flipX = !spriteRenderer.flipX;
        if (collision.gameObject.GetComponent<DeathZone>()) 
        { 
            Destroy(gameObject);
        }

    }

    
}
