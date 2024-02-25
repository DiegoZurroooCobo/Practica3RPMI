using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class TrapBall : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.gameObject.GetComponent<EnemyMovement>() != null) 
        {
            collision.AddComponent<RandomDebuff>();
            Destroy(gameObject);
        }
        if(collision.gameObject.GetComponent<MarioMovement>() != null) 
        {
            collision.AddComponent<RandomDebuff>();
            Destroy(gameObject);
        }
    }
}
