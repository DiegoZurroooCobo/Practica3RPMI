using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescene : MonoBehaviour
{
    public AudioClip ChangeSceneMusic;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement changescene = collision.GetComponent<MarioMovement>();
        if(changescene) 
        {
            GameManager.instance.LoadScene("Practica3.1_changeScene"); //Permite cambiar a la segunda escena
            AudioManager.instance.PlayAudio(ChangeSceneMusic,"ChangeSceneMusic");
        }
    }
}
