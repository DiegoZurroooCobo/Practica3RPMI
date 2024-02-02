using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if(collision.gameObject.GetComponent<MarioMovement>()) 
        {
            GameManager.instance.SetScore(50);
            GameManager.instance.GetScore();
            Destroy(gameObject);
        }
    }
}
