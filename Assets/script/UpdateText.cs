using System;
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
        GameManager.instance.SetLifes(3); // Da el valor de las vidas al empezar el juego 
    }
    // Update is called once per frame
    void Update()
    {
        switch (variable) // El Switch es un if else mas simplificado 
        {
            case GameManager.GameManagerVariables.TIME:   
                textComponent.text = "Time: " + GameManager.instance.GetTime().ToString("0.00"); // Muestra en pantalla el texto con el tiempo actualizsdo creado en el GM 
                break;
            case GameManager.GameManagerVariables.SCORE:
                textComponent.text = "Score: " + GameManager.instance.GetScore(); // Muestra en pantalla el texto con la puntuacion de las monedas y los enemigos
                break;
            case GameManager.GameManagerVariables.LIFES:
                textComponent.text = "Lifes: " + GameManager.instance.GetLifes(); // Muestra en pantalla el texto con las vidas, que aumentan o disminuyen 
                break;
            default:
                break;
        }
    }
    // El EventSystem se encarga de habilitar los eventos del usuario (click, scroll, botones del teclado) sobre los elementos de la pantalla.
    // No se toca ni se cambia nada. Se crea automaticamente al crear UI
}
