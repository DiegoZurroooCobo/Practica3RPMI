using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Changescene : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        //if (collision.gameObject.GetComponent<MarioMovement>())
        //{
        //transform.position = new Vector2(-9, 25);           
        //}
        MarioMovement changescene = collision.GetComponent<MarioMovement>();
        if(changescene) 
        {
            changescene.Changescene(); 
        }
    }
}
