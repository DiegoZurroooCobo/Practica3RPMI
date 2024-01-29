using System.Collections;
using System.Collections.Generic;
using TMPro; // Avisa al codigo que vamos a utilizar otro codigo 
using UnityEngine;

public class UpdateText : MonoBehaviour
{
    public GameManager.GameManagerVariables variable;
    private TMP_Text textComponent;

    private void Start()
    {
        textComponent = gameObject.GetComponent<TMP_Text>();
    }
    // Update is called once per frame
    void Update()
    {
        //if(variable == GameManager.GameManagerVariables.TIME) 
        //{ 
        
        //}
        //else if(variable == GameManager.GameManagerVariables.SCORE) 
        //{ 
        
        //}
        //else 
        //{ 
        
        //}
        switch (variable) 
        {
            case GameManager.GameManagerVariables.TIME:
                textComponent.text = "TIME: " + GameManager.instance.GetTime(); 
                break;
            case GameManager.GameManagerVariables.SCORE:
                textComponent.text = "SCORE: " + GameManager.instance.GetScore(); 
                break;
            default:
                break;
        }
    }

    // El EventSystem se encarga de habilitar los eventos del usuario (click, scroll, botones del teclado) sobre los elementos de la pantalla.
    // No se toca ni se cambia nada. Se crea automaticamente al crear UI
}
