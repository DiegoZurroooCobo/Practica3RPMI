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
            GameManager.instance.SetLifes(GameManager.instance.GetLifes() + 1 );
            Destroy(gameObject);

            List<GameObject> ListCoins = new List<GameObject>();
            ListCoins.Add(gameObject);
            foreach (GameObject gameObject in ListCoins)
            {
                Debug.Log(gameObject);
            }

            AudioManager.instance.PlayAudio(healthClip, "coinClip");
        }
    }
}
