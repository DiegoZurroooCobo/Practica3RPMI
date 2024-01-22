using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        MarioMovement changescene = collision.GetComponent<MarioMovement>();
        if(changescene) 
        {
            changescene.Changescene(); //Permite cambiar a la segunda escena
        }
    }
}
