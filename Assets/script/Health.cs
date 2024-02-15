using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Health : MonoBehaviour
{
    public AudioClip healthClip;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.GetComponent<MarioMovement>())
        {
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() + 1 ); // Al recoger una vida, el contador de vidas aumenta en 1 
            Destroy(gameObject);

            List<GameObject> ListCoins = new List<GameObject>();
            ListCoins.Add(gameObject);
            foreach (GameObject gameObject in ListCoins)
            {
                Debug.Log(gameObject);  // crea una lista que registra las vidas recogidas 
            }

            AudioManager.instance.PlayAudio(healthClip, "coinClip"); // Suena el efecto de sonido de las vidas 
        }
    }
}
