using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // La instancia de la clase
    
    private float time;
    private int score;
    private void Awake()
    {
        // Singleton dos caracteristicas: - Solo existe una instancia de esa clase
        //                                - Accesible para todo el mundo
        if (!instance) // Isma entra a la fiesta. Si no hay nadie guapo, él es la persona mas guapa (Si el GM entra en la escena y no hay otra GM, él se vuelve principal)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye en la siguiente escena
        }
        else // si insta tiene informacion
        { 
            Destroy(gameObject); // se destruye el gameObject, para que no haya dos o mas GM
        }
    }
    // Start is called before the first frame update
    void Start()
    {
         
    }

    // Update is called once per frame
    void Update()
    {
        time += Time.deltaTime;
    }

    public float GetTime() 
    {
        return time;
    }

    public int GetScore() 
    { 
        return score;
    }

    public int SetScore(int value) 
    { 
        return value; 
    }
}
