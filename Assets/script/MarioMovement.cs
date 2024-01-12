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
    private Vector2 dir;
    private bool isjumping;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2(0, 0);

        if (Input.GetKey(rightKey))
        {
            dir = new Vector2(1, 0);
        }
        else if (Input.GetKey(leftKey))
        {
            dir = new Vector2(-1, 0);
        }

        if (Input.GetKey(jumpkey))
        {
            isjumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;

        isjumping = false;
        if (isjumping && IsGrounded())
        {
            rb.AddForce(Vector2.up * jumpForce * rb.gravityScale, ForceMode2D.Impulse);
        }
        
        print(IsGrounded());

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
        //Lanza un rayo desde el centro del personaje hacia abajo. El rayo llega hasta ala distancia definicda. solo va a detectar colisiones si se encuentran dentro del Raycast
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

    public void Loadscene()
    {
        SceneManager.LoadScene("practica 3");
    }
}
