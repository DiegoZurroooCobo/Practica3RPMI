using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class DeathZone : MonoBehaviour
{
    public string sceneToLoad;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement playerDeath = collision.GetComponent<MarioMovement>();
        if(playerDeath) 
        { 
            playerDeath.ResetPosition();
        }

    }
}
