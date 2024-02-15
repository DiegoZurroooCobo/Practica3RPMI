using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    public AudioClip coinClip;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MarioMovement>())
        {
            GameManager.instance.SetScore(GameManager.instance.GetScore() + 50); // Aumenta la puntuacion en 50 al colisionar
            Destroy(gameObject); // El objeto se destruye 

            List<GameObject> ListCoins = new List<GameObject>(); 
            ListCoins.Add(gameObject);
            foreach (GameObject gameObject in ListCoins)
            {
                Debug.Log(gameObject);  //Se hace una lista con un seguimiento de las monedas obtenidas
            }
            AudioManager.instance.PlayAudio(coinClip, "coinClip"); // Suena el efecto de sonido de recoger moneda 
        }
    }
}
