using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using System.Xml;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpkey, attackKey, attackKey2;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask; // Capa de colisiones 
    public AudioClip jumpClip, respawnClip;

    private Rigidbody2D rb;
    private SpriteRenderer rSprite;
    private Vector2 dir;
    private bool isjumping;
    private Animator animator;
    private float currentTime = 0;
    private float MaxTime;
    private Vector2 originalPosition;
    // Prohibido declararse un public GameManager >:(

    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
        originalPosition = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(0, 0);

        if (Input.GetKey(rightKey))    //Se mueve a la derecha
        {
            rSprite.flipX = false;
            dir = new Vector2(1, 0);
        }
        else if (Input.GetKey(leftKey)) //Se mueve a la izquierda
        {
            rSprite.flipX = true;
            dir = new Vector2(-1, 0);
        }

        isjumping = false;      
        if (Input.GetKey(jumpkey))  // al presionar la tecla desiganda para saltar, el booleano se vuelve verdadero
        {
            isjumping = true;
        }
    
        if (dir != Vector2.zero)    // Si la direccion es contraria cero, inicia la animacion de caminar. Si no, vuelve a la animacion de Idle
        {
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }
        // Realiza la primera animacion de ataque 
        if(Input.GetKey(attackKey)) 
        {

            animator.Play("Attack_1");
        }
        // Realiza la segunda aniamcion de ataque
        if(Input.GetKey(attackKey2)) 
        {

            animator.Play("Attack_2");
        }

        currentTime += Time.deltaTime;
        MaxTime = 15f;
        if(currentTime > MaxTime)   // Al pasar 15 segundos, se realiza una segunda animacion de Idle
        {
            animator.Play("Idle_2");
            currentTime = 0; 
        }
    }

    private void FixedUpdate()
    {
        //print(IsGrounded());
        if (isjumping && IsGrounded())  //Si se encuntra saltando Y se encuentra en el suelo, se ejcuta la animacion de saltar y el persoanje aplica una fuerza en el eje Y
        {
            animator.Play("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse); // Se añade una fuerza en el eje Y teniendo en cuenta la fuerza del salto y la gravedad del RB
            AudioManager.instance.PlayAudio(jumpClip, "JumpSound");
            
        }

        if( dir != Vector2.zero ) 
        { 
            float currentYnevl = rb.velocity.y;
            Vector2 nVel = dir * speed;
            nVel.y = currentYnevl;

            rb.velocity = nVel;
        }
    }

    private bool IsGrounded()   // un booleano que comprueba si el personaje se encuenta en el suelo 
    {   // Lo que devuelve     // Lo que recibe
        RaycastHit2D colission = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        //Lanza un rayo desde el centro del personaje hacia abajo. El rayo llega hasta la distancia definida. solo va a detectar colisiones si se encuentran dentro del Raycast
        if (colission)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos() //Dibuja dentro de la escena un rayo desde el centro del personaje 
    {
        Gizmos.color = Color.red;
        Gizmos.DrawRay(transform.position, Vector2.down * rayDistance);
    }

    //public void DeathZone(string sceneName) // al entratr en contacto con la death zone, vuelve a cargar la escena 
    //{
    //    animator.Play("Death");
    //    SceneManager.LoadScene(sceneName);
    //    animator.Play("Respawn");
    //}
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyMovement>()) 
        {
            animator.Play("Death");
            SceneManager.LoadScene("practica 3");   // Resetea la escena entera, volviendo al inicio
            AudioManager.instance.ClearAudios();
            animator.Play("Respawn");
            AudioManager.instance.PlayAudio(respawnClip, "respawnClip");
        }
    }

    public void ResetPosition() //Resetea la posicion original del personaje al ser destruido
    {
        animator.Play("Death");
        transform.position = originalPosition;
        AudioManager.instance.ClearAudios();
        animator.Play("Respawn");
        AudioManager.instance.PlayAudio(respawnClip, "respawnClip");
    }
}
