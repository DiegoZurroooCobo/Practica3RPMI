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
    public KeyCode rightKey, leftKey, jumpkey;
    public float speed, jumpForce, rayDistance;
    public LayerMask groundMask; // Capa de colisiones 

    private Rigidbody2D rb;
    private SpriteRenderer rSprite;
    private Vector2 dir;
    private bool isjumping;
    private Animator animator;
    private float currentTime = 0;
    private float MaxTime;
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

        if (Input.GetKey(rightKey))
        {
            rSprite.flipX = false;
            dir = new Vector2(1, 0);
        }
        else if (Input.GetKey(leftKey))
        {
            rSprite.flipX = true;
            dir = new Vector2(-1, 0);
        }

        isjumping = false;
        if (Input.GetKey(jumpkey))
        {
            isjumping = true;
        }
    
        if (dir != Vector2.zero)
        {
            animator.SetBool("IsWalking", true);
        }
        else 
        {
            animator.SetBool("IsWalking", false);
        }

        currentTime += Time.deltaTime;
        if(currentTime > MaxTime) 
        {
            animator.SetBool("TimeWaiting", true);
            MaxTime = 15f;
        }

        else
        {
            animator.SetBool("TimeWaiting", false);
        }
    }

    private void FixedUpdate()
    {
        if (isjumping && IsGrounded())
        {
            animator.SetBool("IsJumping", true);
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

        else
        {
            animator.SetBool("IsJumping", false);
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

    public void DeathZone() // al entratr en contacto con la death zone, vuelve a cargar la escena 
    {
        SceneManager.LoadScene("practica 3");
    }

    public void Changescene() 
    {
        SceneManager.LoadScene("practica 3");
    }
}
