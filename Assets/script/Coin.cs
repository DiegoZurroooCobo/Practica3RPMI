using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Coin : MonoBehaviour
{
    private void Start()
    {
        
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<MarioMovement>())
        {
            GameManager.instance.SetScore(50);
            Destroy(gameObject);
            GameManager.instance.GetScore();

            List<GameObject> ListCoins = new List<GameObject>();
            ListCoins.Add(gameObject);
            foreach (GameObject gameObject in ListCoins)
            {
                Debug.Log(gameObject);
            }
        }
    }
}
