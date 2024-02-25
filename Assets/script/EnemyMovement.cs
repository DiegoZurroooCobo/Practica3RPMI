using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class EnemyMovement : MonoBehaviour
{
    public GameObject Player, TrapBall;
    public float speed, currentTime = 0, MaxTime;
    private Vector2 dir;
    private Rigidbody2D rb;
    private float distance;
    private SpriteRenderer spriteRenderer;
    public AudioClip deathClip;
    //public AudioClip MovementMusic;
    void Start()
    {
        //Player = FindAnyObjectByType<MarioMovement>().gameObject;
        rb = GetComponent<Rigidbody2D>();
        Movement();
        spriteRenderer = rb.GetComponent<SpriteRenderer>();
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
        currentTime += Time.deltaTime;
        if (currentTime >= MaxTime) 
        {
            MaxTime = 10f;
            GameObject trapBall = Instantiate(TrapBall, new Vector2( Random.Range(transform.position.x - 3, transform.position.x + 3), transform.position.y), Quaternion.identity);
            //trapBall.GetComponent<TrapBall>().dir.x = Random.Range(-3 , 3);
            currentTime = 0;
        }

    }

    void Movement()
    {
        do
        {
            dir.x = Random.Range(-1, 2);    //Se mueve de manera aleatoria en el eje X, aunque NUNCA su posicion es 0
        } while (dir.x == 0);

        //AudioManager.instance.PlayAudio3D(MovementMusic, "MovementMusic");
    }
    private void FixedUpdate()  //Se actualiza mas a menudo para que las fisicas vayan mejor 
    {
        rb.velocity = dir * speed;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<MarioMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 100);
            Destroy(gameObject); //Si colisiona con el personaje, el enemigo es destruido
            AudioManager.instance.PlayAudio(deathClip, "deathClip");
            // Destroy(gameObject.transform.parent.gameObject) //Para destruir al padre si el codigo esta en el hijo
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
