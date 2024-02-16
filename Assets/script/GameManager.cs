using System.Collections;
using System.Collections.Generic;
using System.Data;
using UnityEngine;
using UnityEngine.SceneManagement;

public class GameManager : MonoBehaviour
{
    public static GameManager instance; // La instancia de la clase
    public KeyCode Escape;
    public enum GameManagerVariables { TIME, SCORE, LIFES };
    public AudioClip enterClip, exitClip;
    // enum = para facilitar la lectura del codigo 
    private float time;
    private int score, lifes;
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
        if(Input.GetKeyDown(KeyCode.Escape))    // Al presionar el boton de Escape te permite volver al menu desde cualquier escena 
        {
            SceneManager.LoadScene("Menu");
            AudioManager.instance.ClearAudios();
        }
        
    }
    // Getter = para obtener el valor de una variable 
    public float GetTime() // obtiene el tiempo
    {
        return time;
    }

    //public void ResetTime() 
    //{ 
    //    time = 0;
    //}
    public int GetScore() // Obtiene el valor de la puntuacion
    { 
        return score;
    }
    // Setter = para setear el valor de una variable 
    public void SetScore(int value) // Da el valor a la puntuacion
    {
        score = value; 
    }

    public int GetLifes() // obtiene el valor de las vidas
    {
        return lifes;
    }

    public void SetLifes(int value) // da el valor a las vidas 
    {
        lifes = value;
    }

    // callback == funcion que se va a llamar en el on click de los botones 
    public void LoadScene(string SceneName) // Te lleva a la escena que te selecciones como la primera
    {
        Debug.Log("Play!");
        AudioManager.instance.PlayAudio(enterClip, "enterClip");
        SceneManager.LoadScene(SceneName);
        // Limpia todos los sonidos que estan sonando 
        AudioManager.instance.ClearAudios();
    }

    public void ExitGame() // Te permite salir del menu del juego 
    {
        Debug.Log("Exit!");
        AudioManager.instance.PlayAudio(exitClip, "exitClip");
        Application.Quit();
    }
}
