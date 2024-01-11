using JetBrains.Annotations;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.SceneManagement;

[RequireComponent(typeof(Rigidbody2D))]
public class MarioMovement : MonoBehaviour
{
    public KeyCode rightKey, leftKey, jumpkey;
    public float speed, jumpforce, rayDistance;
    public LayerMask groundMask;

    private Rigidbody2D rb;
    private Vector2 dir;
    private bool isjumping = false;
    // Start is called before the first frame update
    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        dir = new Vector2 (0, 0);

        if(Input.GetKey(rightKey)) 
        {
           dir = new Vector2(1, 0);
        }
        else if(Input.GetKey(leftKey)) 
        {
           dir = new Vector2(-1, 0);
        }

        if(Input.GetKeyDown(jumpkey) && IsGrounded()) 
        { 
            isjumping = true;
        }
    }

    private void FixedUpdate()
    {
        rb.velocity = dir * speed;
           
        
        if(isjumping) 
        {
            rb.AddForce(new Vector2(0, jumpforce * rb.gravityScale));
            isjumping = false;
        } 
    }

    private bool IsGrounded() 
    {
        RaycastHit2D[] raycastHits = Physics2D.RaycastAll(transform.position, Vector2.down, rayDistance);
        
        foreach(RaycastHit2D raycastHit in raycastHits) 
        {
            //if(raycastHit.collider.gameObject.CompareTag("ground"))
            //if(raycastHit.collider.gameObject.layer == (groundMask))
            {
                return true;
            }
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
