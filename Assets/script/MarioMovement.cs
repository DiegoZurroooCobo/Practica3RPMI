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

    private Rigidbody2D rb;
    private SpriteRenderer rSprite;
    private Vector2 dir;
    private bool isjumping;
    private Animator animator;
    private float currentTime = 0;
    private float MaxTime = 15f;
    private Vector2 originalPosition;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        rSprite = GetComponent<SpriteRenderer>();
        animator = GetComponent<Animator>();
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
        if (Input.GetKey(jumpkey)) 
        {
            isjumping = true;
        }
    
        if (dir != Vector2.zero)    // Si la direccion es contraria cero, inicia la animacion de caminar. Si no, vuelev a la animacion de Idle
        {
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }

        if(Input.GetKey(attackKey)) 
        {

            animator.Play("Attack_1");
        }
      
        if(Input.GetKey(attackKey2)) 
        {

            animator.Play("Attack_2");
        }

        currentTime += Time.deltaTime;
        if(currentTime > MaxTime) 
        {
            animator.Play("Idle_2");
            currentTime = 0; 
        }
    }

    private void FixedUpdate()
    {
        print(IsGrounded());
        if (isjumping && IsGrounded())  //Si se encuntra saltando Y se encuentra en el suelo, se ejcuta la animacion de saltar y el persoanje aplica una fuerza en el eje Y
        {
            animator.Play("Jumping");
            rb.velocity = new Vector2(rb.velocity.x, 0);
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
        }

        if( dir != Vector2.zero ) 
        { 
            float currentYnevl = rb.velocity.y;
            Vector2 nVel = dir * speed;
            nVel.y = currentYnevl;

            rb.velocity = nVel;
        }

    }

    private bool IsGrounded()
    {
        RaycastHit2D colission = Physics2D.Raycast(transform.position, Vector2.down, rayDistance, groundMask);
        //Lanza un rayo desde el centro del personaje hacia abajo. El rayo llega hasta la distancia definida. solo va a detectar colisiones si se encuentran dentro del Raycast
        if (colission)
        {
            return true;
        }
        return false;
    }

    private void OnDrawGizmos()
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

    public void Changescene() 
    {
        SceneManager.LoadScene("Practica3.1_changeScene");
    }

    public void EndScene() 
    {
        SceneManager.LoadScene("Practica 3.End");
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyMovement>()) 
        {
            animator.Play("Respawn");
            SceneManager.LoadScene("practica 3");
        }
    }

    public void ResetPosition() //Resetea la posicion original del personaje al ser destruido
    {
        animator.Play("Death");
        transform.position = originalPosition;
    }
}
