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
        //Player = FindAnyObjectByType<MarioMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Movement();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
        GameManager.instance.GetScore();
    }

    // Update is called once per frame
    void Update()
    {
        distance = Vector2.Distance(transform.position, Player.transform.position); // Mide la distancia entre el enemigo y el personaje 
        Vector2 dir = Player.transform.position - transform.position; //La distancia del jugador menos la distancia actual del enemigo.

        if (distance < 3.5) //Si la distancia es menor que 3.5, el enemigo se movera en la direccion del jugador
        {
            transform.position = Vector2.MoveTowards(transform.position, new Vector2(Player.transform.position.x, transform.position.y), speed * Time.deltaTime);
        }
        //La posicion del enemigo cambia a la direccion donde se encuentre el personaje. 

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
        do
        {
            dir.x = Random.Range(-1, 2);    //Se mueve de manera aleatoria en el eje X, aunque NUNCA su posicion es 0
        } while (dir.x == 0);
    }
    private void FixedUpdate()  //Se actualiza mas a menudo para que las fisicas vayan mejor 
    {
        rb.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MarioMovement>())
        {

            Destroy(gameObject);    //Si colisiona con el personaje, el enemigo es destruido
            // Destroy(gameObject.transform.parent.gameObject) // Para destruir al padre si el codigo esta en el hijo
        }
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        //if(collision.gameObject.GetComponent<TilemapCollider2D>()) 
        //{
        //    dir.x = -dir.x;
        //}
        dir.x = -dir.x; //Si colisiona, se invierte en el eje X
        spriteRenderer.flipX = !spriteRenderer.flipX; // El sprite se da la vuelta al girar en el eje X
        if (collision.gameObject.GetComponent<DeathZone>())
        {
            Destroy(gameObject);    //Si colisiona con la Death Zone, se destruye
        }
    }


}
