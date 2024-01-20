using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
   public GameObject Player;
   private Vector2 target; 
   public float speed;
   private Vector2 dir;
   private Rigidbody2D rb;
    private float distance;
    private SpriteRenderer spriteRenderer;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Movement();
        target = Player.transform.position; //Asigna como objetivo la posicion del jugador 
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position); // Mide la distancia entre el enemigo y el personaje 
        Vector2 dir = Player.transform.position - transform.position; 

        if(distance < 3.5) //Si la distancia es menor que 3.5, el enemigo se movera en la direccion del jugador
        { 
        transform.position = Vector2.MoveTowards(transform.position, Player.transform.position, speed * Time.deltaTime);      
        }

        if(dir.x  > 0) 
        { 
            spriteRenderer.flipX = false;
        }
        else if(dir.x < 0) 
        { 
            spriteRenderer.flipX = true;
        }
    }

    void Movement() 
    {
        dir.x = Random.Range(-1, 2);       
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<TilemapCollider2D>()) 
        {
            dir.x = -dir.x;
        }
       
        MarioMovement PlayerDeath = collision.gameObject.GetComponent<MarioMovement>();
        if(PlayerDeath) 
        {
            PlayerDeath.DeathZone();
        }
        if(collision.gameObject.GetComponent<DeathZone>()) 
        { 
            Destroy(collision.gameObject);
        }

    }
}
