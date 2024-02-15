using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EndScene : MonoBehaviour
{
    public AudioClip changeSceneClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement EndScene = collision.GetComponent<MarioMovement>();
        if(EndScene != null )
        {

            GameManager.instance.LoadScene("Practica 3.End");  //Cambia la escena final
            AudioManager.instance.PlayAudio(changeSceneClip, "changeSceneClip");
        }
    }
}
