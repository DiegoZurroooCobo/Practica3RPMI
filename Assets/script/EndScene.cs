using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement EndScene = collision.GetComponent<MarioMovement>();
        if(EndScene != null )
        {

            EndScene.EndScene();
        }
    }
}
