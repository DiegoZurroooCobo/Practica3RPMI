using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // La instancia de la clase
    public KeyCode Escape;
    public enum GameManagerVariables { TIME, SCORE };
    // enum = para facilitar la lectura del codigo 
    private float time;
    private int score;
    private void Awake() // primer metodo que se ejecuta en Unity 
    {
        // Singleton dos caracteristicas: - Solo existe una instancia de esa clase
        //                                - Accesible para todo el mundo
        if (!instance) // Isma entra a la fiesta. Si no hay nadie guapo, él es la persona mas guapa (Si el GM entra en la escena y no hay otra GM, él se vuelve principal)
        { 
            instance = this;
            DontDestroyOnLoad(gameObject); // No se destruye al cambiar de escena
        }
        else // si instance tiene informacion
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
        if(Input.GetKeyDown(KeyCode.Escape)) 
        {
            SceneManager.LoadScene("Menu");
        }
    }
    // Getter = para obtener el valor de una variable 
    public float GetTime() 
    {
        return time;
    }
    public int GetScore() 
    { 
        return score;
    }
    // Setter = para setear el valor de una variable 
    public int SetScore(int value) 
    { 
        return value; 
    }

    // callback == funcion que se va a llamar en el on click de los botones 
    public void LoadScene(string SceneName) 
    { 
         SceneManager.LoadScene(SceneName); 
    }
}
