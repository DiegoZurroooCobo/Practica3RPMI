using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CheckSides : MonoBehaviour
{
    public GameObject enemy;
    private Vector2 dir;
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<TilemapCollider2D>()) 
        {
            
        }
    }
}
